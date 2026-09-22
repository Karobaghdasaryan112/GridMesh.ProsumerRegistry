namespace GridMesh.ProsumerRegistry.Domain.Common.Results
{
    public class Error
    {
        private readonly string _message;
        private readonly ErrorType _errorType;
        private readonly string _code;

        private Error(string code, string message, ErrorType errorType)
        {
            _message = message;
            _errorType = errorType;
            _code = code;
        }

        public ErrorType GetErrorType() => _errorType;
        public string GetMessage() => _message;
        
        public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);
        public static Error Failure(string code, string message) => new(code, message, ErrorType.Failure);
        public static Error Validation(string code, string message) => new(code, message, ErrorType.Validation);
        public static Error NotFound(string code, string message) => new(code, message, ErrorType.NotFound);
        public static Error Conflict(string code, string message) => new(code, message, ErrorType.Conflict);
        public static Error Unauthorized(string code, string message) => new(code, message, ErrorType.Unauthorized);
    }

    public enum ErrorType
    {
        Failure = 0,
        Validation = 1,
        NotFound = 2,
        Conflict = 3,
        Unauthorized = 4
    }
}