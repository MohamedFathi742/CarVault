using CarVault.Application.DTOs.Requests;
using CarVault.Application.DTOs.Responses;
using CarVault.Domain.Entities;

namespace CarVault.Application.Interfaces;
public interface ICategoryRepository:IGenericRepository<Category>
{
    Task <IEnumerable<Category?>> GetCategoryWithCarAsync();
    Task<PaginationResponse<Category>> GetPagedAsync(CategoryFilterRequest  categoryFilter);

}
