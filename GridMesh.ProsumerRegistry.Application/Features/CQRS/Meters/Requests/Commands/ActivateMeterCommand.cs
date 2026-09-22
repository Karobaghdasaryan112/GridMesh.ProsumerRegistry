using GridMesh.ProsumerRegistry.Domain.Common.Results;
using MediatR;

namespace GridMesh.ProsumerRegistry.Application.Features.CQRS.Meters.Requests.Commands
{
    public class ActivateMeterCommand : BaseRequest, IRequest<Result>
    {
        public Guid MeterId { get; set; }
    }
}