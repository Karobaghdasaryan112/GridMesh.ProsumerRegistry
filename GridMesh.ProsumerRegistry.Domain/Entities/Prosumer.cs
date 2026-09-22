using GridMesh.ProsumerRegistry.Domain.Common.Entities.Base;
using GridMesh.ProsumerRegistry.Domain.Common.Entities.Enums;

namespace GridMesh.ProsumerRegistry.Domain.Entities
{
    public class Prosumer : AggregateRoot
    {
        private Prosumer()
        {

        }

        public string Name { get; private set; } = null!;

        public ProsumerStatus Status { get; private set; }

        public ICollection<Meter> Meters { get; private set; } = new List<Meter>();

    }
}