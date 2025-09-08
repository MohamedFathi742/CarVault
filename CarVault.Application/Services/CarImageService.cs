using CarVault.Application.Interfaces;
using CarVault.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace CarVault.Application.Services;
public class CarImageService(ICarImageRepository repository,IFileStorageService fileStorageService) : ICarImageService
{
    private readonly ICarImageRepository _repository = repository;
    private readonly IFileStorageService _fileStorageService = fileStorageService;

    public async Task<IEnumerable<string>> UploadCarImagesAsync(int carId, IFormFileCollection files)
    {
     var urls=new List<string>();

        foreach (var file in files)
        {
            
            using var stream=file.OpenReadStream();

            var url = await _fileStorageService.SaveFileAsync(stream, file.FileName, "Uploads");
            urls.Add(url);
        }
        var carImages = urls.Select(url => new CarImage
        {

            CarId = carId,
            ImageUrl= url
        });
        await _repository.UploadImages(carImages);
        return urls;
    }
    public async Task<IEnumerable<string>> GetCarImagesAsync(int carId)
    {
        var images = await _repository.GetImagesByCarId(carId);
        return images.Select(i => i.ImageUrl).ToList();
    }

  
    //public async Task<IEnumerable<CarImageResponse>> GetAllCarImagesAsync()
    //{
    //   var image=await _repository.GetAllAsync();
    //    return image.Adapt<IEnumerable<CarImageResponse>>();
    //}

    //public async Task<CarImageResponse?> GetCarImagByIdAsync(int id)
    //{
    //    var image = await _repository.GetByIdAsync(id);
    //    return image.Adapt<CarImageResponse>();
    //}

    //public async Task<CarImageResponse?> AddCarImagAsync(CreateCarImageRequest request)
    //{
    //   var image= request.Adapt<CarImage>();    
    //    await _repository.AddAsync(image);
    //    return image.Adapt<CarImageResponse>();
    //}

    //public async Task DeleteCarImagAsync(int id)
    //{
    //    var image = await _repository.GetByIdAsync(id);
    // await   _repository.DeleteAsync(image!);
    //}



}
