namespace GridMesh.ProsumerRegistry.Domain.Common.Results
{
    public class ResultT<TValue>(TValue? value, bool isSuccess, Error error) : Result(isSuccess, error)
    {
        private readonly TValue _value = value;

        public TValue Value => IsSuccess
            ? _value!
            : throw new InvalidOperationException("Cannot access the value of a failed result.");

        public static implicit operator ResultT<TValue>(TValue value)
            => Success<TValue>(value);

        public static implicit operator ResultT<TValue>(Error error)
            => Failure<TValue>(error);
    }
}