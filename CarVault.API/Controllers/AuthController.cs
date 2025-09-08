using CarVault.Application.DTOs.Requests;
using CarVault.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarVault.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService service) : ControllerBase
{
    private readonly IAuthService _service = service;


    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody]RegisterUserRequest request,[FromQuery]string role)
    {
        
        var user = await _service.RegisterUserAsync(request, role);
       
            return Ok(user);
    
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserRequest request ) 
    {
        var user = await _service.LoginUserAsync(request);
        return Ok(user);
    
    }


}
