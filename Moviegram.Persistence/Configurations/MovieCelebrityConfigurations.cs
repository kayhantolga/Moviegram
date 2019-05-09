using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moviegram.Domain.Entities;

namespace Moviegram.Persistence.Configurations
{
    public class MovieShowTimeConfigurations : IEntityTypeConfiguration<MovieShowTime>
    {
        public void Configure(EntityTypeBuilder<MovieShowTime> builder)
        {
            builder.ToTable("MovieShowTimes");
            builder.HasOne(r => r.Movie).WithMany(r => r.MovieShowTimes).HasForeignKey(r => r.MovieId);
        }
    }
}