using CarVault.Application.DTOs.Requests;
using CarVault.Application.DTOs.Responses;
using CarVault.Domain.Entities;

namespace CarVault.Application.Interfaces;
public interface ICarRepository:IGenericRepository<Car>
{
    //Task<CarWithImageAndCategoryResponse?> GetCarWithImageAsync(int id);
    Task<IEnumerable<Car>> GetCarWithCategoryAsync(int categoryId);
    Task<IEnumerable<Car>> GetCarWithImageAndCategoryAsync();
    Task<PaginationResponse<Car>> GetPagedAsync(CarFilterRequest carFilter);

}
