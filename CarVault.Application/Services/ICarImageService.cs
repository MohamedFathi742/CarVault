using Microsoft.AspNetCore.Http;

namespace CarVault.Application.Services;
public interface ICarImageService
{
    //Task<IEnumerable<CarImageResponse>> GetAllCarImagesAsync();
    //Task<CarImageResponse?> GetCarImagByIdAsync(int id);
    //Task<CarImageResponse?> AddCarImagAsync(CreateCarImageRequest request);
    //Task DeleteCarImagAsync(int id);

    Task<IEnumerable<string>> UploadCarImagesAsync(int carId, IFormFileCollection files);
    Task<IEnumerable<string>> GetCarImagesAsync(int carId);

}
