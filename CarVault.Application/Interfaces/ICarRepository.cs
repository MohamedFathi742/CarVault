using CarVault.Application.DTOs.Responses;
using CarVault.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Application.Interfaces;
public interface ICarRepository:IGenericRepository<Car>
{
    //Task<CarWithImageAndCategoryResponse?> GetCarWithImageAsync(int id);
    Task<IEnumerable<CarWithImageAndCategoryResponse>> GetCarWithCategoryAsync(int categoryId);
    Task<IEnumerable<CarWithImageAndCategoryResponse>> GetCarWithImageAndCategoryAsync();

}
