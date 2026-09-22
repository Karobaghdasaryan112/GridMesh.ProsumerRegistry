using GridMesh.ProsumerRegistry.Domain.Entities;
using GridMesh.ProsumerRegistry.Domain.Interfaces.Repositories;
using GridMesh.ProsumerRegistry.Persistance.Common.Repositories;
using GridMesh.ProsumerRegistry.Persistance.Data;

namespace GridMesh.ProsumerRegistry.Persistance.Repositories
{
    public class ProsumerRepository(ProsumerRegistryDbContext context)
        : BaseRepository<Prosumer>(context), IProsumerRepository
    {
    }
}