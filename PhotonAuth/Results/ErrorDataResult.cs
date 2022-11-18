using PhotonAuth.Common;

namespace PhotonAuth.Results;

public class ErrorDataResult<T> : DataResult<T>
{
    public ErrorDataResult(T data, ResultCodes resultCode, string message) : base(data, resultCode)
    {
        Message = message;
    }

    public ErrorDataResult(T data, ResultCodes resultCode) : base(data, resultCode)
    {
    }

    public ErrorDataResult(ResultCodes resultCode, string message) : base(default, resultCode)
    {
        Message = message;
    }

    public ErrorDataResult(ResultCodes resultCode) : base(default, resultCode)
    {
    }

    public string Message { get; set; }
}