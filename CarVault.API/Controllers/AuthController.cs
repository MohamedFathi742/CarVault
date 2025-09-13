using CarVault.Application.DTOs.Requests;
using CarVault.Application.DTOs.Responses;
using CarVault.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarVault.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService service) : ControllerBase
{
    private readonly IAuthService _service = service;

    [HttpPost("register")]
    [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromForm] RegisterUserRequest request, [FromQuery] string role = "User")
    {


        var user = await _service.RegisterUserAsync(request, role);

        return Ok(new
        {
            Success = true,
            Message = "User registered successfully",
            Data = user
        });
    }

    [HttpPost("login")]
    [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
    {
        var user = await _service.LoginUserAsync(request);

        return Ok(new
        {
            Success = true,
            Message = "Login successful",
            Data = user
        });
    }
}