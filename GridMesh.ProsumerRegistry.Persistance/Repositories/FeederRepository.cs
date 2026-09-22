using GridMesh.ProsumerRegistry.Domain.Entities;
using GridMesh.ProsumerRegistry.Domain.Interfaces.Repositories;
using GridMesh.ProsumerRegistry.Persistance.Common.Repositories;
using GridMesh.ProsumerRegistry.Persistance.Data;

namespace GridMesh.ProsumerRegistry.Persistance.Repositories
{
    public class FeederRepository(ProsumerRegistryDbContext context)
        : BaseRepository<Feeder>(context), IFeederRepository
    {
    }
}