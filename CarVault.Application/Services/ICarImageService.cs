using CarVault.Application.DTOs.Responses;
using Microsoft.AspNetCore.Http;

namespace CarVault.Application.Services;
public interface ICarImageService
{
    Task<IEnumerable<CarImageResponse>> UploadCarImagesAsync(int carId, IFormFileCollection files);
    Task<IEnumerable<CarImageResponse>> GetAllAsync();
    Task<IEnumerable<CarImageResponse>> GetCarImageByCarIdAsync(int carId);
    Task<CarImageResponse> GetByIdAsync(int carImageId);

    Task DeleteImageAsync(int imageId);
}
