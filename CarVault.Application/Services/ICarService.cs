using CarVault.Application.DTOs.Requests;
using CarVault.Application.DTOs.Responses;

namespace CarVault.Application.Services;
public interface ICarService
{
    Task<PaginationResponse<CarResponse>> GetPagedAsync(CarFilterRequest filter);
    Task<IEnumerable<CarWithImageAndCategoryResponse>> GetCarWithImageAndCategoryAsync();
    Task<IEnumerable<CarResponse>> GetAllCarsAsync();
  //  Task<CarWithImageAndCategoryResponse?> GetCarWithImageAsync(int id);
    Task<IEnumerable<CarWithImageAndCategoryResponse>> GetCarWithCategoryAsync(int categoryId);
    Task<CarResponse?> GetCarByIdAsync(int id);
    Task<CarResponse?> AddCarAsync(CreateCarRequest request, string userId);
    Task <CarResponse?>UpdateCarAsync(UpdateCarRequest request,int id,string SellerId,bool isAdmin);
    Task DeleteCarAsync(int id, string SellerId, bool isAdmin);
  

}
