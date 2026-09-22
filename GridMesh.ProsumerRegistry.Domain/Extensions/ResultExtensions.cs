using System.Net;
using GridMesh.ProsumerRegistry.Domain.Common.Results;
using Microsoft.AspNetCore.Mvc;

namespace GridMesh.ProsumerRegistry.Domain.Extensions
{
    public static class ResultExtensions
    {
        public static IActionResult ToApiResult(this Result result)
        {
            return result.IsSuccess ? new NoContentResult() : MapError(result.Error);
        }

        public static IActionResult ToApiResult<TValue>(this ResultT<TValue> result)
        {
            return result.IsSuccess ? new OkObjectResult(result) : MapError(result.Error);
        }

        private static IActionResult MapError(Error error)
        {
            var apiResult = error.GetErrorType() switch
            {
                ErrorType.Validation => new ApiResult(
                    HttpStatusCode.BadRequest,
                    error.GetMessage(),
                    error.GetErrorType()),

                ErrorType.NotFound => new ApiResult(
                    HttpStatusCode.NotFound,
                    error.GetMessage(),
                    error.GetErrorType()),

                ErrorType.Failure => new ApiResult(
                    HttpStatusCode.BadRequest,
                    error.GetMessage(),
                    error.GetErrorType()),

                ErrorType.Conflict => new ApiResult(
                    HttpStatusCode.Conflict,
                    error.GetMessage(),
                    error.GetErrorType()),

                ErrorType.Unauthorized => new ApiResult(
                    HttpStatusCode.Unauthorized,
                    error.GetMessage(),
                    error.GetErrorType()),

                _ => throw new ArgumentOutOfRangeException()
            };

            return new ObjectResult(apiResult)
            {
                StatusCode = (int)apiResult.StatusCode
            };
        }
    }
}