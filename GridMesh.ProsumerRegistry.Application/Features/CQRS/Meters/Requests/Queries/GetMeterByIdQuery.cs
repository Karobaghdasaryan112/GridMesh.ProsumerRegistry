using GridMesh.ProsumerRegistry.Application.DTOs.Meter;
using GridMesh.ProsumerRegistry.Domain.Common.Results;
using MediatR;

namespace GridMesh.ProsumerRegistry.Application.Features.CQRS.Meters.Requests.Queries
{
    public class GetMeterByIdQuery : BaseRequest, IRequest<ResultT<GetMeterDTO>>
    {
        public Guid Id { get; set; }
    }
}