using GridMesh.ProsumerRegistry.Application.Features.CQRS.Meters.Requests.Commands;
using GridMesh.ProsumerRegistry.Domain.Common.Interfaces.Repositories;
using GridMesh.ProsumerRegistry.Domain.Common.Results;
using GridMesh.ProsumerRegistry.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GridMesh.ProsumerRegistry.Application.Features.CQRS.Meters.Hendlers.Commands
{
    public class ActivateMeterCommandHandler(
        ILogger<ActivateMeterCommandHandler> logger,
        IMeterRepository meterRepository,
        IUnitOfWork unitOfWork)
        : BaseHandler(unitOfWork, logger),
            IRequestHandler<ActivateMeterCommand, Result>
    {
        public async Task<Result> Handle(
            ActivateMeterCommand request,
            CancellationToken cancellationToken)
        {
            var meter = await meterRepository
                .GetById(request.MeterId)
                .FirstOrDefaultAsync(cancellationToken);

            if (meter is null)
            {
                logger.LogWarning(
                    "Meter {MeterId} was not found.",
                    request.MeterId);

                return Result.Failure(Error.NotFound(
                    "Meter.NotFound",
                    $"Meter '{request.MeterId}' was not found."));
            }

            var activationResult = meter.Activate();

            if (activationResult.IsFailure)
            {
                logger.LogWarning(
                    "Failed to activate meter {MeterId}.",
                    request.MeterId);

                return activationResult;
            }

            var saveResult = await UnitOfWork.SaveChangesAsync(cancellationToken);

            if (saveResult.IsFailure)
            {
                logger.LogError(
                    "Failed to save activation of meter {MeterId}.",
                    request.MeterId);

                return saveResult;
            }

            return saveResult;
        }
    }
}