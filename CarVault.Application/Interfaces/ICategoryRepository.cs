using CarVault.Application.DTOs.Responses;
using CarVault.Domain.Entities;

namespace CarVault.Application.Interfaces;
public interface ICategoryRepository:IGenericRepository<Category>
{
    Task <IEnumerable<CategoryWithCarResponse?>> GetCategoryWithCarAsync();

}
