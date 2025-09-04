using CarVault.Application.DTOs.Requests;
using CarVault.Application.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Application.Services;
public interface ICarImageService
{
    Task<IEnumerable<CarImageResponse>> GetAllCarImagesAsync();
    Task<CarImageResponse?> GetCarImagByIdAsync(int id);
    Task<CarImageResponse?> AddCarImagAsync(CreateCarImageRequest request);
    Task DeleteCarImagAsync(int id);



}
