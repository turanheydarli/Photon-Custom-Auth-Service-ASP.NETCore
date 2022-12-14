using PhotonAuth.Models;
using PhotonAuth.Results;
using Result = PhotonAuth.Models.Result;

namespace PhotonAuth.Services.Authentication;

public interface IClientService
{
    Task<IDataResult<UserDto>> Authenticate(UserLoginDto userLoginDto);
    Task<Result> Register(UserRegisterDto userRegisterDto);
}