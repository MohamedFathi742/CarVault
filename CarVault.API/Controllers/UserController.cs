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
        var users = await _service.GetAllUseresAsync();
        return Ok(users);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("pagination")]
    public async Task<IActionResult> Pagination([FromQuery] UserFilterRequest userFilter)
    {
        var users = await _service.GetPagedAsync(userFilter);
        return Ok(users);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var user = await _service.GetUserByIdAsync(id);
        return Ok(user);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("by-email")]
    public async Task<IActionResult> GetByEmail([FromQuery] string email)
    {
        var user = await _service.GetUserByEmailAsync(email);
        return Ok(user);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("{id}/with-orders")]
    public async Task<IActionResult> GetUserWithOrders(string id)
    {
        var user = await _service.GetUserWithOrdersAsync(id);
        return Ok(user);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(UpdateUserRequest request, string id)
    {
        var updatedUser = await _service.UpdateUserAsync(request, id);
        return Ok(updatedUser);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        await _service.DeleteUserAsync(id);
        return NoContent();
    }
}



