using PhotonAuth.Common;
using PhotonAuth.Models;
using PhotonAuth.Results;
using PhotonAuth.Services.Repositories;
using PhotonAuth.Services.Security;
using Result = PhotonAuth.Models.Result;

namespace PhotonAuth.Services.Authentication;

public class ClientService : IClientService
{
    private readonly IRepository<User> _userRepository;

    public ClientService(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IDataResult<User>> Authenticate(UserLoginDto userLoginDto)
    {
        User user = await _userRepository.GetAsync(u => u.Username == userLoginDto.Username);

        if (user == null)
        {
            return new ErrorDataResult<User>(ResultCodes.InvalidParameters, "Invalid parameters.");
        }

        bool result = HashingHelper.VerifyPasswordHash(userLoginDto.Password, user.PasswordHash, user.PasswordSalt);

        if (!result)
        {
            return new ErrorDataResult<User>(ResultCodes.WrongCredentials, "Authentication failed. Wrong credentials.");
        }

        return new SuccessDataResult<User>(user, user.Username);
    }

    public async Task<Result> Register(UserRegisterDto userRegisterDto)
    {
        User user = await _userRepository.GetAsync(u => u.Username == userRegisterDto.Username);

        if (user != null)
        {
            return new Result
            {
                Message = "Authentication failed. Wrong credentials.",
                ResultCode = (int)ResultCodes.WrongCredentials
            };
        }

        HashingHelper.CreatePasswordHash(userRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

        user = await _userRepository.InsertAsync(new User()
        {
            Username = userRegisterDto.Username,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        });

        return new Result
        {
            UserId = user.Username,
            ResultCode = (int)ResultCodes.Success
        };
    }
}