using PhotonAuth.Models;

namespace PhotonAuth.Services.Authentication;

public interface IClientService
{
    Task<Result> Authenticate(UserLoginDto userLoginDto);
    Task<Result> Register(UserRegisterDto userRegisterDto);
}