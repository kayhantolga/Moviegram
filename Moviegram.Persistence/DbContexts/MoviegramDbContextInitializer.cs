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
        }

        private static void SeedMovies(MoviegramDbContext context)
        {
            context.SaveChanges();
        }
    }
}