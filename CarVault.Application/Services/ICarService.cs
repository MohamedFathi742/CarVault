using CarVault.Application.DTOs.Requests;
using CarVault.Application.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Application.Services;
public interface ICarService
{
    Task<IEnumerable<CarWithImageAndCategoryResponse>> GetCarWithImageAndCategoryAsync();
    Task<IEnumerable<CarResponse>> GetAllCarsAsync();
  //  Task<CarWithImageAndCategoryResponse?> GetCarWithImageAsync(int id);
    Task<IEnumerable<CarWithImageAndCategoryResponse>> GetCarWithCategoryAsync(int categoryId);
    Task<CarResponse?> GetCarByIdAsync(int id);
    Task<CarResponse?> AddCarAsync(CreateCarRequest request);
    Task <CarResponse?>UpdateCarAsync(UpdateCarRequest request,int id);
    Task DeleteCarAsync(int id);
  

}
