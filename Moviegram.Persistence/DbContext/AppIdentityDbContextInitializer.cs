namespace Moviegram.Persistence.DbContext
{
    public static class AppIdentityDbContextInitializer
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