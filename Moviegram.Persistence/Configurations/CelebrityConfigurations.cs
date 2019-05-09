using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moviegram.Domain.Entities;

namespace Moviegram.Persistence.Configurations
{
    public class CelebrityConfigurations : IEntityTypeConfiguration<Celebrity>
    {
        public void Configure(EntityTypeBuilder<Celebrity> builder)
        {
            builder.ToTable("Celebrities");
            builder.Property(r => r.Name).HasMaxLength(256);

        }
    }
}
