using PhotonAuth.Common;

namespace PhotonAuth.Results;

public class Result : IResult
{
    public Result(ResultCodes result)
    {
        ResultCode = (int)result;
    }

    public int ResultCode { get; set; }
}