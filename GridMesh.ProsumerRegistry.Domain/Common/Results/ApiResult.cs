using System.Net;

namespace GridMesh.ProsumerRegistry.Domain.Common.Results
{
    public class ApiResult
    {
        private HttpStatusCode _statusCode;
        private string _errorMessage;
        private ErrorType _errorType;

        public HttpStatusCode StatusCode => _statusCode;
        public string ErrorMessage => _errorMessage;
        public ErrorType ErrorType => _errorType;

        public ApiResult(
            HttpStatusCode statusCode,
            string errorMessage,
            ErrorType errorType)
        {
            _statusCode = statusCode;
            _errorMessage = errorMessage;
            _errorType = errorType;
        }
    }
}