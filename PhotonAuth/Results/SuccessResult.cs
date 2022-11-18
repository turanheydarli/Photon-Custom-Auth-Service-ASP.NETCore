using PhotonAuth.Common;

namespace PhotonAuth.Results;

public class SuccessResult : Result
{
    public SuccessResult(string userId) : base(ResultCodes.Success)
    {
        UserId = userId;
    }

    public SuccessResult() : base(ResultCodes.Success)
    {
    }

    public string UserId { get; set; }
}