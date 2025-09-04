using CarVault.Application.DTOs.Requests;
using CarVault.Application.Services;
using Microsoft.AspNetCore.Http;
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
        var images = await _service.GetAllCarImagesAsync();
        return Ok(images);

    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {

        var image = await _service.GetCarImagByIdAsync(id);
        return Ok(image);

    }

    [HttpPost]
    public async Task<IActionResult> AddCategory(CreateCarImageRequest request)
    {

        var image = await _service.AddCarImagAsync(request);
        return Ok(image);

    }
   
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {

        await _service.DeleteCarImagAsync(id);
        return NoContent();

    }





}
