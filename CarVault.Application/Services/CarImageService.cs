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
public class CarImageService(IGenericRepository<CarImage> repository) : ICarImageService
{
    private readonly IGenericRepository<CarImage> _repository = repository;
    public async Task<IEnumerable<CarImageResponse>> GetAllCarImagesAsync()
    {
       var image=await _repository.GetAllAsync();
        return image.Adapt<IEnumerable<CarImageResponse>>();
    }

    public async Task<CarImageResponse?> GetCarImagByIdAsync(int id)
    {
        var image = await _repository.GetByIdAsync(id);
        return image.Adapt<CarImageResponse>();
    }

    public async Task<CarImageResponse?> AddCarImagAsync(CreateCarImageRequest request)
    {
       var image= request.Adapt<CarImage>();    
        await _repository.AddAsync(image);
        return image.Adapt<CarImageResponse>();
    }

    public async Task DeleteCarImagAsync(int id)
    {
        var image = await _repository.GetByIdAsync(id);
     await   _repository.DeleteAsync(image);
    }

    
    
}
