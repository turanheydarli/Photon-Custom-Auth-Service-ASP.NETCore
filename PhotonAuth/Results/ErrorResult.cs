using PhotonAuth.Common;

namespace PhotonAuth.Results;

public class ErrorResult : Result
{
    public ErrorResult(string message, ResultCodes resultCode) : this(resultCode)
    {
        Message = message;
    }

    public ErrorResult(ResultCodes resultCode) : base(resultCode)
    {
    }

    public string Message { get; set; }
}