using System;
using System.Linq;
using Bogus;
using Moviegram.Domain.Entities;

namespace Moviegram.Persistence.DbContexts
{
    public static class MoviegramDbContextInitializer
    {
        public static void Initialize(MoviegramDbContext context)
        {
            SeedEverything(context);
        }

        private static void SeedEverything(MoviegramDbContext context)
        {
            context.Database.EnsureCreated();

            //If db already initialized do not seed anything
            if (context.Movies.Any()) return;

            var testMovies = new Faker<Movie>()
                .RuleFor(o => o.Id, f => Guid.NewGuid())
                .RuleFor(o => o.Genre, f => f.Lorem.Paragraphs())
                .RuleFor(o => o.Title, f => $"{f.Hacker.Noun()} {f.Hacker.Verb()}");

            var testCelebrities = new Faker<Celebrity>()
                .RuleFor(u => u.Id, f => Guid.NewGuid())
                .RuleFor(u => u.Name, f => $"{f.Name.FirstName()} {f.Name.LastName()}")
                .RuleFor(u => u.ProfilePhoto, f => f.Internet.Avatar());

            var celebrities = testCelebrities.Generate(100);
            context.Celebrities.AddRange(celebrities);
            var movies = testMovies.Generate(100);

            var random = new Random();
            foreach (var movie in movies)
            {
                //Take max 10 random actor and make a movie
                var actorCount = random.Next(10);
                var tempActors = celebrities.OrderBy(r => Guid.NewGuid()).Take(actorCount).ToList();
                foreach (var celebrity in tempActors)
                    movie.Actors.Add(new MovieCelebrity
                    {
                        CelebrityId = celebrity.Id,
                        MovieId = movie.Id
                    });

                var timeCount = random.Next(5);
                var startTime = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 9, 0, 0);
                //Generate average movie time
                var averageTime = (double)9 / timeCount;

                for (var i = 0; i < timeCount; i++)
                    movie.MovieShowTimes.Add(new MovieShowTime
                    {
                        Id = Guid.NewGuid(),
                        ShowTimeStart = startTime.AddMinutes(averageTime * 60 * i + 30),
                        ShowTimeEnd = startTime.AddMinutes(averageTime * 60 * (i + 1))
                    });
                context.Movies.Add(movie);
            }

            context.SaveChanges();
        }
    }
}