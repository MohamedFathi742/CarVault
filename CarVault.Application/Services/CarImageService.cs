using CarVault.Application.DTOs.Responses;
using CarVault.Application.Interfaces;
using CarVault.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Http;

namespace CarVault.Application.Services;
public class CarImageService(ICarImageRepository repository,IFileStorageService fileStorageService) : ICarImageService
{
    private readonly ICarImageRepository _repository = repository;
    private readonly IFileStorageService _fileStorageService = fileStorageService;

    public async Task<IEnumerable<CarImageResponse>> UploadCarImagesAsync(int carId, IFormFileCollection files)
    {
     var urls=new List<string>();

        foreach (var file in files)
        {

            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            var allowed = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
            if (!allowed.Contains(ext)) throw new Exception("invalied extintion");

            if (file.Length == 0) continue;

            using var stream=file.OpenReadStream();

            var uniqueName = $"{Guid.NewGuid()}_{file.FileName}";

            var url = await _fileStorageService.SaveFileAsync(stream, uniqueName, "Uploads/CarImages");
            urls.Add(url);
        }
        var carImages = urls.Select(url => new CarImage
        {

            CarId = carId,
            ImageUrl= url
        }).ToList();
        await _repository.UploadImages(carImages);
        return urls.Adapt<IEnumerable<CarImageResponse>>();
    }

    public async Task<IEnumerable<CarImageResponse>> GetCarImagesAsync(int carId)
    {
        var images = await _repository.GetImagesByCarId(carId);
        return images.Adapt<IEnumerable<CarImageResponse>>();
    }


    public async Task<IEnumerable<CarImageResponse>> GetCarImageByCarIdAsync(int carId)
    {
        var image = await _repository.GetImagesByCarId(carId);
        return image.Adapt<IEnumerable<CarImageResponse>>();
    }

    

    public async Task<CarImageResponse> GetByIdAsync(int carImageId)
    {
       var car =await _repository.GetByIdAsync(carImageId)??throw new Exception("Not Found");

        return car.Adapt<CarImageResponse>();
    }


    public async Task DeleteImageAsync(int imageId)
    {
       var image=await _repository.GetByIdAsync(imageId) ?? throw new Exception("Not Found");

        await _fileStorageService.DeleteFileAsync(image.ImageUrl);
        await _repository.DeleteAsync(image);

    }

    public async Task<IEnumerable<CarImageResponse>> GetAllAsync()
    {
       var images=await _repository.GetAllAsync();
        return images.Adapt<IEnumerable<CarImageResponse>>();
    }
}
