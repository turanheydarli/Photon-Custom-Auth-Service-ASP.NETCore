using PhotonAuth.Common;

namespace PhotonAuth.Results;

public class SuccessDataResult<T> : DataResult<T>
{
    public SuccessDataResult(T data, string userId) : base(data, ResultCodes.Success)
    {
        UserId = userId;
    }

    public SuccessDataResult(T data) : base(data, ResultCodes.Success)
    {
    }

    public SuccessDataResult() : base(default, ResultCodes.Success)
    {
    }

    public string UserId { get; set; }
}