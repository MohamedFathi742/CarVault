using CarVault.Application.DTOs.Requests;
using CarVault.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarVault.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoryController(ICategoryService service) : ControllerBase
{
    private readonly ICategoryService _service = service;


    [HttpGet]
    public async Task<IActionResult> GetAll() 
    {
    var category= await _service.GetAllCategoriesAsync();
        return Ok(category);
    
    }

    [HttpGet("with-car")]
    public async Task<IActionResult> GetCategoryWithCar() 
    {

    var category= await _service.GetCategoryWithCarAsync();
        return Ok(category);
    
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory(CreateCategoryRequest request ) 
    {

    var category= await _service.AddCategoryAsync(request);
        return Ok(category);
    
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryRequest request ,int id) 
    {

    var category= await _service.UpdateCategoryAsync(request,id);
        return NoContent();
    
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id) 
    {

     await _service.DeleteCategoryAsync(id);
        return NoContent();
    
    }




}
