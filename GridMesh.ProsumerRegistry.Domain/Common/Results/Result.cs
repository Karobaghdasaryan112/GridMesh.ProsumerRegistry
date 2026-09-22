namespace GridMesh.ProsumerRegistry.Domain.Common.Results
{
    public class Result
    {
        protected Result(bool isSuccess, Error error)
        {
            switch (isSuccess)
            {
                case true when error != Error.None:
                    throw new InvalidOperationException("A successful result cannot contain an error.");
                case false when error == Error.None:
                    throw new InvalidOperationException("A failed result must contain an error.");
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }
        
        public static Result Success() => new(true, Error.None);
        public static Result Failure(Error error) => new(false, error);

        public static ResultT<TValue> Success<TValue>(TValue value) =>
            new(
                value: value,
                isSuccess: true,
                error: Error.None);

        public static ResultT<TValue> Failure<TValue>(Error error) =>
            new(
                value: default(TValue),
                isSuccess: false,
                error: error);
    }
}