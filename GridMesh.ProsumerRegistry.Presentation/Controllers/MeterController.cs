using Asp.Versioning;
using GridMesh.ProsumerRegistery.Common;
using GridMesh.ProsumerRegistry.Application.Features.CQRS.Meters.Requests.Commands;
using GridMesh.ProsumerRegistry.Domain.Common.Results;
using GridMesh.ProsumerRegistry.Domain.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GridMesh.ProsumerRegistery.Controllers
{
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MeterController(IMediator mediator) : BaseController(mediator)
    {
        [HttpPost("{meterId:guid}/activate")]
        [ProducesErrorResponseType(typeof(Error))]
        public async Task<IActionResult> MeterActivation(Guid meterId)
        {
            var command = new ActivateMeterCommand
            {
                MeterId = meterId,
            };

            var serviceResult = await _mediator.Send(command);

            return serviceResult.ToApiResult();
        }
    }
}