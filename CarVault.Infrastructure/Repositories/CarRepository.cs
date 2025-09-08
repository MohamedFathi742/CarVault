using CarVault.Application.DTOs.Requests;
using CarVault.Application.DTOs.Responses;
using CarVault.Application.Interfaces;
using CarVault.Domain.Entities;
using CarVault.Infrastructure.Common;
using CarVault.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarVault.Infrastructure.Repositories;
public class CarRepository : GenericRepository<Car>, ICarRepository
{
    private readonly ApplicationDbContext _context;
    public CarRepository(ApplicationDbContext context) : base(context) => _context = context;
    //public async Task<CarWithImageAndCategoryResponse?> GetCarWithImageAsync(int id)
    //{
    //    return await _context.Cars
    //        .Where(c => c.Id == id)
    //        .Include(c=>c.CarImages)
    //        .ProjectToType<CarWithImageAndCategoryResponse>()
    //        .AsNoTracking()
    //        .FirstOrDefaultAsync();


    //}
    public async Task<IEnumerable<Car>> GetCarWithCategoryAsync(int categoryId)
    {
        return await _context.Cars
              .Where(c => c.CategoryId == categoryId)
             .Include(c => c.CarImages)
               .Include(c => c.Category)
              //.ProjectToType<CarWithImageAndCategoryResponse>()
              .AsNoTracking()
              .ToListAsync();
    }

    public async Task<IEnumerable<Car>> GetCarWithImageAndCategoryAsync()
    {
        return await _context.Cars
             .Include(c => c.CarImages)
             .Include(c => c.Category)
             // .ProjectToType<CarWithImageAndCategoryResponse>()
             .AsNoTracking()
             .ToListAsync();

    }

    public async Task<PaginationResponse<Car>> GetPagedAsync(CarFilterRequest carFilter)
    {
        IQueryable<Car> query = _context.Cars.AsNoTracking();


        if (!string.IsNullOrWhiteSpace(carFilter.Brand))
        {
            query = query.Where(c => c.Brand != null && c.Brand.Contains(carFilter.Brand));
        }

        if (carFilter.MinPrice.HasValue)
        {
            query = query.Where(c => c.Price >= carFilter.MinPrice.Value);
        }
        if (carFilter.MaxPrice.HasValue)
        {
            query = query.Where(c => c.Price <= carFilter.MaxPrice.Value);
        }
        if (carFilter.IsSold.HasValue)
        {
            query = query.Where(c => c.IsSold == carFilter.IsSold.Value);
        }
        return await query.ToPagedResultAsync(
            carFilter,
            searchPredicate: c => c.Brand.ToLower().Contains(carFilter.Search!)
            );
    }
}
