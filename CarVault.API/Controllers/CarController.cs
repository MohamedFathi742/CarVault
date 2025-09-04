using CarVault.Application.DTOs.Requests;
using CarVault.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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

    //[HttpGet("WithImage{id}")]
    //public async Task<IActionResult> GetCarWithImage(int id) 
    //{
    
    //var car =await _service.GetCarWithImageAsync(id);
    //    return Ok(car);
    
    //}
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


    [HttpPost]
    public async Task<IActionResult> AddCar([FromForm]CreateCarRequest request )
    {

        var car = await _service.AddCarAsync(request);
        return Ok(car);

    }
    [HttpPut]
    public async Task<IActionResult> UpdateCar(UpdateCarRequest request,int id )
    {

        var car = await _service.UpdateCarAsync(request,id);
        return NoContent();

    }
    [HttpDelete]
    public async Task<IActionResult> DeleteCar(int id )
    {

     await  _service.DeleteCarAsync(id);
        return NoContent();
    }


}
