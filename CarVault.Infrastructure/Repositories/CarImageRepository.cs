using CarVault.Application.Interfaces;
using CarVault.Domain.Entities;
using CarVault.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarVault.Infrastructure.Repositories;
public class CarImageRepository : GenericRepository<CarImage>, ICarImageRepository
{
    private readonly ApplicationDbContext _context;
    public CarImageRepository(ApplicationDbContext context) : base(context) => _context = context;
    public async Task UploadImages(IEnumerable<CarImage> images)
    {
        await _context.CarImages.AddRangeAsync(images);
        await _context.SaveChangesAsync();
    }
    public async Task<IEnumerable<CarImage>> GetImagesByCarId(int carId)
    {

        return await _context.CarImages
            .Where(i => i.CarId == carId)
            .AsNoTracking()
            .ToListAsync();

    }


}
