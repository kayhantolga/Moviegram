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

            //This will help to generate same random data
            Randomizer.Seed = new Random(1);

            var testMovies = new Faker<Movie>()
                .RuleFor(o => o.Id, f => f.Random.Guid())
                .RuleFor(o => o.Genre, f => f.Lorem.Paragraphs())
                .RuleFor(o => o.Title, f => $"{f.Lorem.Sentence(3)}")
                .RuleFor(o => o.Poster, (f, o) => f.Image.PlaceholderUrl(1024, 1024, o.Title, f.Internet.Color().Replace("#", "")));

            var testCelebrities = new Faker<Celebrity>()
                .RuleFor(u => u.Id, f => f.Random.Guid())
                .RuleFor(u => u.Name, f => $"{f.Name.FirstName()} {f.Name.LastName()}")
                .RuleFor(u => u.ProfilePhoto, f => f.Internet.Avatar());

            var celebrities = testCelebrities.Generate(100);
            context.Celebrities.AddRange(celebrities);
            var movies = testMovies.Generate(100);

            var random = new Random();
            //Assign actors to movies
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

                var movieTimes = random.Next(60, 180);
                var startTime = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 9, 0, 0);
                var tempTime = startTime;

                //Add showTimes to movies
                do
                {
                    var tempShowTime = new MovieShowTime
                    {
                        Id = Guid.NewGuid(),
                        ShowTimeStart = tempTime,
                        ShowTimeEnd = tempTime.AddMinutes(movieTimes)
                    };
                    movie.MovieShowTimes.Add(tempShowTime);
                    tempTime = tempTime.AddMinutes(movieTimes + 30);
                } while (tempTime < startTime.AddHours(9));

               
                context.Movies.Add(movie);
            }

            context.SaveChanges();
        }
    }
}