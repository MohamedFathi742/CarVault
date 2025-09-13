using CarVault.Application.DTOs.Requests;
using CarVault.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarVault.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CarController(ICarService service) : ControllerBase
{
    private readonly ICarService _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var cars = await _service.GetAllCarsAsync();
        return Ok(cars);
    }

    [HttpGet("with-category-image")]
    public async Task<IActionResult> GetAllCarsWithImageAndCategory()
    {
        var cars = await _service.GetCarWithImageAndCategoryAsync();
        return Ok(cars);
    }

    [HttpGet("pagination")]
    public async Task<IActionResult> Pagination([FromQuery] CarFilterRequest request)
    {
        var cars = await _service.GetPagedAsync(request);
        return Ok(cars);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCarById(int id)
    {
        var car = await _service.GetCarByIdAsync(id);
        return Ok(car);
    }

    [HttpGet("by-category/{id:int}")]
    public async Task<IActionResult> GetCarByCategoryId(int id)
    {
        var cars = await _service.GetCarWithCategoryAsync(id);
        return Ok(cars);
    }

    [Authorize(Roles = "Seller,Admin")]
    [HttpPost]
    public async Task<IActionResult> AddCar([FromBody] CreateCarRequest request)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var car = await _service.AddCarAsync(request, userId!);
        return CreatedAtAction(nameof(GetCarById), new { id = car.Id }, car);
    }

    [Authorize(Roles = "Seller,Admin")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCar([FromBody] UpdateCarRequest request, int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var admin = User.IsInRole("Admin");

        var updatedCar = await _service.UpdateCarAsync(request, id, userId!, admin);
        return Ok(updatedCar);
    }

    [Authorize(Roles = "Seller,Admin")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCar(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var admin = User.IsInRole("Admin");

        await _service.DeleteCarAsync(id, userId!, admin);
        return Ok(new { Message = "Car deleted successfully" });
    }
}
