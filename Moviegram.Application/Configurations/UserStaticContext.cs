﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Moviegram.Common.Utilities;
using Moviegram.Domain.Interfaces;
using Moviegram.Persistence.DbContexts;

namespace Moviegram.Application.Configurations
{
    public class RequestStatics : IUserStaticContext
    {
        public RequestStatics(IHttpContextAccessor contextAccessor)
        {
            if (contextAccessor == null)
            {
                return;
            }
            _context = contextAccessor.HttpContext;
            InitAll();
        }
        public RequestStatics(HttpContext context)
        {
            if (context == null)
            {
                return;
            }
            _context = context;
            InitAll();
        }

        private readonly HttpContext _context;

        public Cursor Cursor { get; set; }
        public MoviegramDbContext Db { get; set; }

        public Task InitAll()
        {
            SetCursor();
            SetDb();
            return Task.CompletedTask;
        }
        
        public Task SetCursor()
        {
            Cursor = _context.Request.GetCursor();
            return Task.CompletedTask;
        }

        public Task SetDb()
        {
            Db = _context.RequestServices.GetService<MoviegramDbContext>();
            return Task.CompletedTask;
        }

    }
}