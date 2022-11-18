namespace PhotonAuth.Results;

public interface IDataResult<out T> : IResult
{
    T Data { get; }
}