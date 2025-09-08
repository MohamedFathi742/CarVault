using CarVault.Domain.Entities;

namespace CarVault.Application.Interfaces;
public interface ICarImageRepository : IGenericRepository<CarImage>
{
    Task UploadImages(IEnumerable<CarImage> images);
    Task<IEnumerable<CarImage>> GetImagesByCarId(int carId);

}
