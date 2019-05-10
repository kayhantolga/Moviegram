using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moviegram.Domain.Entities;

namespace Moviegram.Persistence.Configurations
{
    public class MovieCelebrityConfigurations : IEntityTypeConfiguration<MovieCelebrity>
    {
        public void Configure(EntityTypeBuilder<MovieCelebrity> builder)
        {
            builder.ToTable("MovieCelebrities");
            builder.HasKey(q =>
                new
                {
                    q.CelebrityId,
                    q.MovieId
                });
            builder.HasOne(r => r.Movie).WithMany(r => r.Actors).HasForeignKey(r => r.MovieId);
            builder.HasOne(r => r.Celebrity).WithMany(r => r.Movies).HasForeignKey(r => r.CelebrityId);
        }
    }
}