using System.Runtime.InteropServices.JavaScript;
using GridMesh.ProsumerRegistry.Domain.Common.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GridMesh.ProsumerRegistery.Common
{

    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesErrorResponseType(typeof(Error))]
    [ProducesResponseType<Result>(200)]
    public class BaseController : ControllerBase
    {
        protected IMediator _mediator { get; }

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}