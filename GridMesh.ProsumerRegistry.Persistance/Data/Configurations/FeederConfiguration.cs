using GridMesh.ProsumerRegistry.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GridMesh.ProsumerRegistry.Persistance.Data.Configurations
{
    public class FeederConfiguration : IEntityTypeConfiguration<Feeder>
    {
        public void Configure(EntityTypeBuilder<Feeder> builder)
        {
            builder.ToTable("Feeders");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(f => f.CapacityKw)
                .HasPrecision(18, 3)
                .IsRequired();

            builder.Property(f => f.Status)
                .IsRequired();
        }
    }
}