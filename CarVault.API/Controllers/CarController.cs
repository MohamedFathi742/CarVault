using CarVault.Application.DTOs.Requests;
using CarVault.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace CarVault.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CarController(ICarService service) : ControllerBase
{
    private readonly ICarService _service = service;

    [HttpGet("with-category-image")]
    
    public async Task<IActionResult> GetAllCarsWithImageAndCategory()
    {

        var car = await _service.GetCarWithImageAndCategoryAsync();
        return Ok(car);

    }
    [HttpGet]

    public async Task<IActionResult> GetAll()
    {

        var car = await _service.GetAllCarsAsync();
        return Ok(car);

    }

    [HttpGet("pagination")]
    public async Task<IActionResult> Pagination([FromQuery]CarFilterRequest request)
    {

        var car = await _service.GetPagedAsync(request);
        return Ok(car);

    }
    [HttpGet("by-Category{id}")]
    public async Task<IActionResult> GetCarByCategoryId(int id ) 
    {
    
    var car =await _service.GetCarWithCategoryAsync(id);
        return Ok(car);
    
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCarById(int id) 
    {
    
    var car =await _service.GetCarByIdAsync(id);
        return Ok(car);
    
    }

    [Authorize(Roles = "Seller,Admin")]
    [HttpPost]
    public async Task<IActionResult> AddCar([FromBody]CreateCarRequest request )
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        
        var car = await _service.AddCarAsync(request,userId!);
        return Ok(car);

    }
    [Authorize(Roles = "Seller,Admin")]
    [HttpPut]
    public async Task<IActionResult> UpdateCar([FromBody] UpdateCarRequest request,[FromQuery]int id )
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var admin = User.IsInRole("Admin");
        var car = await _service.UpdateCarAsync(request,id, userId!, admin);
        return NoContent();

    }
    [Authorize(Roles = "Seller,Admin")]
    [HttpDelete]
    public async Task<IActionResult> DeleteCar([FromBody]int id )
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var admin = User.IsInRole("Admin");

     await  _service.DeleteCarAsync(id, userId!, admin);
        return NoContent();
    }


}
