using CarVault.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarVault.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CarImageController (ICarImageService service): ControllerBase
{
    private readonly ICarImageService _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var images = await _service.GetAllAsync();
        return Ok(images);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var image = await _service.GetByIdAsync(id);
        return Ok(image);
    }

    [HttpGet("car/{carId:int}")]
    public async Task<IActionResult> GetByCarId(int carId)
    {
        var images = await _service.GetCarImageByCarIdAsync(carId);
        return Ok(images);
    }


    [Authorize(Roles = "Seller,Admin")]
    [HttpPost]
    public async Task<IActionResult> Upload([FromForm] int carId, [FromForm] IFormFileCollection files)
    {
        var images = await _service.UploadCarImagesAsync(carId, files);
        return CreatedAtAction(nameof(GetByCarId), new { carId }, images);
    }

    [Authorize(Roles = "Seller,Admin")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteImageAsync(id);
        return Ok(new { Message = "Image deleted successfully" });
    }
}


