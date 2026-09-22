using GridMesh.ProsumerRegistry.Application.DTOs.Meter;
using GridMesh.ProsumerRegistry.Application.Features.CQRS.Meters.Hendlers.Commands;
using GridMesh.ProsumerRegistry.Application.Features.CQRS.Meters.Requests.Queries;
using GridMesh.ProsumerRegistry.Domain.Common.Interfaces.Repositories;
using GridMesh.ProsumerRegistry.Domain.Common.Results;
using GridMesh.ProsumerRegistry.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GridMesh.ProsumerRegistry.Application.Features.CQRS.Meters.Hendlers.Queries
{
    public class GetMeterByIdQueryHandler(ILogger<GetMeterByIdQueryHandler> logger,
        IMeterRepository meterRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<GetMeterByIdQuery, ResultT<GetMeterDTO>>
    {
        public Task<ResultT<GetMeterDTO>> Handle(GetMeterByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}