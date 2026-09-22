using GridMesh.ProsumerRegistry.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GridMesh.ProsumerRegistry.Persistance.Data.Configurations
{
    public class ProsumerConfiguration : IEntityTypeConfiguration<Prosumer>
    {
        public void Configure(EntityTypeBuilder<Prosumer> builder)
        {
            builder.ToTable("Prosumers");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Status)
                .IsRequired();
        }
    }
}