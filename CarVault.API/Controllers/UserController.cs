using CarVault.Application.DTOs.Requests;
using CarVault.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarVault.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService service) : ControllerBase
{
    private readonly IUserService _service = service;


    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var user = await _service.GetAllUseresAsync();
        return Ok(user);

    }
    [Authorize(Roles = "Admin")]
    [HttpGet("pagenation")]
    public async Task<IActionResult> pagenation([FromQuery]UserFilterRequest userFilter)
    {
        var user = await _service.GetPagedAsync(userFilter);
        return Ok(user);

    }
    [Authorize(Roles = "Admin")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {

        var user = await _service.GetUserByIdAsync(id);
        return Ok(user);

    }
    [Authorize(Roles = "Admin")]
    [HttpGet("email")]
    public async Task<IActionResult> GetByEmail(string email)
    {

        var user = await _service.GetUserByEmailAsync(email);
        return Ok(user);

    }
    [Authorize(Roles = "Admin")]
    [HttpGet("with-orders")]
    public async Task<IActionResult> GetUserWithOrders(string userId)
    {

        var user = await _service.GetUserWithOrdersAsync(userId);
        return Ok(user);

    }
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(UpdateUserRequest request,string userId)
    {

        var user = await _service.UpdateUserAsync(request,userId);
        return NoContent();

    }
    [Authorize(Roles = "Admin")]

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(string id)
    {

        await _service.DeleteUserAsync(id);
        return NoContent();

    }




}
