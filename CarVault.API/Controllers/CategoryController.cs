using CarVault.Application.DTOs.Requests;
using CarVault.Application.Services;
using Microsoft.AspNetCore.Authorization;
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
        var categories = await _service.GetAllCategoriesAsync();
        return Ok(categories);
    }

    [HttpGet("pagination")]
    public async Task<IActionResult> Pagination([FromQuery] CategoryFilterRequest request)
    {
        var categories = await _service.GetPagedAsync(request);
        return Ok(categories);
    }

    [HttpGet("with-car")]
    public async Task<IActionResult> GetCategoryWithCar()
    {
        var categories = await _service.GetCategoryWithCarAsync();
        return Ok(categories);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        var category = await _service.GetCategoryByIdAsync(id);
        return Ok(category);
    }



    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> AddCategory([FromBody] CreateCategoryRequest request)
    {
        var category = await _service.AddCategoryAsync(request);
        return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryRequest request, int id)
    {
        var updatedCategory = await _service.UpdateCategoryAsync(request, id);
        return Ok(updatedCategory); 
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        await _service.DeleteCategoryAsync(id);
        return Ok(new { Message = "Category deleted successfully" });
    }
}


