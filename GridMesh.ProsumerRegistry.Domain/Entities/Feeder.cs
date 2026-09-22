using GridMesh.ProsumerRegistry.Domain.Common.Entities.Base;
using GridMesh.ProsumerRegistry.Domain.Common.Entities.Enums;

namespace GridMesh.ProsumerRegistry.Domain.Entities
{
    public class Feeder : AggregateRoot
    {
        private Feeder()
        {
            
        }
        
        public string Name { get; private  set; } = null!;

        public decimal CapacityKw { get; private set; }

        public FeederStatus Status { get; private set; }

        public ICollection<Meter> Meters { get; private set; } = new List<Meter>();

    }
}