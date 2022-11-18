using Microsoft.AspNetCore.Mvc;
using PhotonAuth.Common;
using PhotonAuth.Models;
using PhotonAuth.Services.Authentication;

namespace PhotonAuth.Controllers;

[ApiController]
[Route("")]
public class AuthController : ControllerBase
{
    private readonly IClientService _clientService;

    public AuthController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet]
    public async Task<IActionResult> Login([FromQuery] UserLoginDto userLoginDto)
    {
        var result = await _clientService.Authenticate(userLoginDto);

        if (result.ResultCode != (int)ResultCodes.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromQuery] UserRegisterDto registerDto)
    {
        Result result = await _clientService.Register(registerDto);

        if (result.ResultCode != (int)ResultCodes.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}