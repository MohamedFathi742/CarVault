using CarVault.Application.DTOs.Requests;
using CarVault.Application.DTOs.Responses;
using CarVault.Application.Interfaces;
using CarVault.Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Application.Services;
public class CategoryService(ICategoryRepository repository):ICategoryService
{
    private readonly ICategoryRepository _repository = repository;

    public async Task<IEnumerable<CategoryResponse>> GetAllCategoriesAsync()
    {
        var categories= await _repository.GetAllAsync();
        return categories.Adapt<IEnumerable<CategoryResponse>>();
    }
    public async Task<IEnumerable< CategoryWithCarResponse?>> GetCategoryWithCarAsync()
    {
        var category = await _repository.GetCategoryWithCarAsync();
        return category;
    }
    public async Task<CategoryResponse?> GetCategoryByIdAsync(int id)
    {
 var category = await _repository.GetByIdAsync(id) ?? throw new Exception("Not found");
        return category.Adapt<CategoryResponse>();
    }
    public async Task<CategoryResponse?> AddCategoryAsync(CreateCategoryRequest request)
    {
        var category = request.Adapt<Category>();
        await _repository.AddAsync(category);
        return category.Adapt<CategoryResponse>();
    }
    public async Task<CategoryResponse?> UpdateCategoryAsync(UpdateCategoryRequest request, int id)
    {
       var category= await _repository.GetByIdAsync(id) ?? throw new Exception("Not found");
        category.Name=request.Name;

        await _repository.UpdateAsync(category);
        return category.Adapt<CategoryResponse>();
    }
    public async Task DeleteCategoryAsync(int id)
    {
        var category = await _repository.GetByIdAsync(id) ?? throw new Exception("Not found");
        await _repository.DeleteAsync(category);
    }

   
    

  
   
}
