using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using static GridMesh.ProsumerRegistry.Persistance.Constants.ApplicationConstants;

namespace GridMesh.ProsumerRegistry.Persistance.Data
{
    public class ProsumerRegistryDbContextDesignTimeFactory
        : IDesignTimeDbContextFactory<ProsumerRegistryDbContext>
    {
        public ProsumerRegistryDbContext CreateDbContext(string[] args)
        {
            var appSettings = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(
                    string.Format(AppsettingsFileName,
                        Environment.GetEnvironmentVariable(DefaultEnvironmentName)),
                    optional: true)
                .Build();

            var optionsBuilder =
                new DbContextOptionsBuilder<ProsumerRegistryDbContext>();

            optionsBuilder.UseSqlServer(appSettings[DefaultConnection]);

            return new ProsumerRegistryDbContext(optionsBuilder.Options);
        }
    }
}