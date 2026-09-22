using GridMesh.ProsumerRegistry.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GridMesh.ProsumerRegistry.Persistance.Data.Configurations
{
    public class MeterConfiguration : IEntityTypeConfiguration<Meter>
    {
        public void Configure(EntityTypeBuilder<Meter> builder)
        {
            builder.ToTable("Meters");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.SerialNumber)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(m => m.SerialNumber)
                .IsUnique();

            builder.Property(m => m.Status)
                .IsRequired();

            builder.HasOne(m => m.Prosumer)
                .WithMany(p => p.Meters)
                .HasForeignKey(m => m.ProsumerId);

            builder.HasOne(m => m.Feeder)
                .WithMany(f => f.Meters)
                .HasForeignKey(m => m.FeederId);
        }
    }
}