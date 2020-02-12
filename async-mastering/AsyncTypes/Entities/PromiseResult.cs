namespace Promises.Entities
{
    public class PromiseResult<T>
    {
        bool HasResult => Status == PromiseStatus.Done;
        T _result;

        public PromiseResult(T result, PromiseStatus status = PromiseStatus.Done)
        {
            Status = status;
            if (!HasResult) _result = default;
            else _result = result;
        }

        public PromiseResult(PromiseStatus status = PromiseStatus.Done)
        {
            Status = status;
        }

        public PromiseStatus Status { get; }
        public T Value => _result;
    }
}
