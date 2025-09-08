using CarVault.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarVault.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CarImageController (ICarImageService service): ControllerBase
{
    private readonly ICarImageService _service = service;
    [Authorize(Roles = "Seller,Admin")]
    [HttpPost]
    public async Task<IActionResult> Upload([FromForm]int carId, IFormFileCollection files) 
    {
    var image= await _service.UploadCarImagesAsync(carId, files);
        return Ok(image);
    
    
    }




}
