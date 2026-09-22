using GridMesh.ProsumerRegistry.Domain.Common.Entities.Base;
using GridMesh.ProsumerRegistry.Domain.Common.Entities.Enums;
using GridMesh.ProsumerRegistry.Domain.Common.Results;
using GridMesh.ProsumerRegistry.Domain.Constants;
using GridMesh.ProsumerRegistry.Domain.Events.Meters;
using static GridMesh.ProsumerRegistry.Domain.Constants.KafkaTopics;

namespace GridMesh.ProsumerRegistry.Domain.Entities
{
    public class Meter : AggregateRoot
    {
        private Meter()
        {

        }

        //----------Entity----------------------

        public string SerialNumber { get; private set; } = null!;

        public MeterStatus Status { get; private set; }

        public Guid ProsumerId { get; private set; }
        public Prosumer Prosumer { get; private set; } = null!;

        public Guid FeederId { get; private set; }
        public Feeder Feeder { get; private set; } = null!;


        public static class MeterErrors
        {
            public static Error InvalidStateTransactionError(Guid meterId, MeterStatus currentStatus) =>
                Error.Conflict($"{nameof(Meter)}.InvalidStateTransition",
                    $"Meter '{meterId}' cannot be activated from status '{currentStatus}'. " +
                    "Only a Certified meter can be activated.");
        }

        //----------Errors----------------------



        //-----------Events----------------------

        public Result Activate()
        {
            if (Status != MeterStatus.Certified)
            {
                return Result.Failure(MeterErrors.InvalidStateTransactionError(Id, Status));
            }

            Status = MeterStatus.Active;
            UpdatedAt = DateTime.UtcNow;

            RaiseDomainEvent(new MeterActivatedDomainEvent(
                meterId: Id,
                prosumerId: ProsumerId,
                feederId: FeederId,
                serialNumber: SerialNumber,
                DateTime.UtcNow,
                topic: MeterActivated));

            return Result.Success();
        }

        //-----------Events----------------------
    }
}