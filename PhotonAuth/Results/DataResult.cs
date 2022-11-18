using PhotonAuth.Common;

namespace PhotonAuth.Results;

public class DataResult<T> : Result, IDataResult<T>
{
    public DataResult(T data, ResultCodes resultCode) : base(resultCode)
    {
        Data = data;
    }

    public T Data { get; }
}