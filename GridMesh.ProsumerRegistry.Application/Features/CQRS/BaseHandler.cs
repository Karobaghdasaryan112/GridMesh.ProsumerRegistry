using GridMesh.ProsumerRegistry.Domain.Common.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GridMesh.ProsumerRegistry.Application.Features.CQRS
{
    public class BaseHandler(IUnitOfWork unitOfWork, ILogger<BaseHandler> logger)
    {
        protected readonly ILogger<BaseHandler> Logger = logger;
        protected readonly IUnitOfWork UnitOfWork = unitOfWork;
    }
}