using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moviegram.Domain.Entities;

namespace Moviegram.Persistence.Configurations
{
    public class MovieConfigurations : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movies");
            builder.Property(r => r.Title).HasMaxLength(256);
        }
    }
}
