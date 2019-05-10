using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moviegram.Application.Configurations;
using Moviegram.Application.Managers;
using Moviegram.Persistence.DbContexts;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Moviegram
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "Moviegram";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
                c.DocExpansion(DocExpansion.None);
            });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MoviegramDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    b => { b.MigrationsAssembly("Moviegram.Persistence"); }));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Moviegram API",
                    Version = "v1",
                    Contact = new Contact
                    {
                        Name = "Tolga Sedat Kayhan",
                        Email = "kayhantolga@gmail.com",
                        Url = "https://www.linkedin.com/in/kayhantolga/"
                    },
                    Description = "<h2>This is the sample project for .Net Core API.</h2>\n" +
                                  "Clients can call all apis without any authorization.\n" +
                                  "Every api has own help description.\n" +
                                  "-------\n" +
                                  "<b>Cursor Usage</b>\n" +
                                  "Every api with listed response object has cursor implementation.\n" +
                                  "You can send your cursor information at Querystring\n" +
                                  "CursorPageSize for size of items (default 20)\n" +
                                  "CursorIndex for index of page(default 0)\n" +
                                  "Sample Usage:\n" +
                                  "mydomain.com/api/movie/movies?CursorPageSize=5&CursorIndex=0\n" +
                                  "mydomain.com/api/movie/movies?CursorPageSize=5&CursorIndex=1\n" +
                                  "-------\n" +
                                  "Feel free to ask questions, Enjoy!"

                });
                c.DescribeAllEnumsAsStrings();
                c.EnableAnnotations();
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvcCore().AddApiExplorer().AddJsonOptions(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            services.AddHttpContextAccessor();
            services.AddScoped<IUserStaticContext, RequestStatics>();
            services.AddScoped<IMovieManager, MovieCoreManager>();
        }
    }
}