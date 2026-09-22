using GridMesh.ProsumerRegistry.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GridMesh.ProsumerRegistry.Persistance.Data
{
    public class ProsumerRegistryDbContext(DbContextOptions<ProsumerRegistryDbContext> options) : DbContext(options)
    {
        public DbSet<Feeder> Feeders { get; set; }
        public DbSet<Prosumer> Prosumers { get; set; }
        public DbSet<Meter> Meters { get; set; }
        public DbSet<OutboxMessage> OutboxMessages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}