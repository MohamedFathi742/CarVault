using CarVault.Application.DTOs.Responses;
using CarVault.Application.Interfaces;
using CarVault.Domain.Entities;
using CarVault.Infrastructure.Persistence;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Infrastructure.Repositories;
public class CarRepository : GenericRepository<Car>, ICarRepository
{
    private readonly ApplicationDbContext _context;
    public CarRepository(ApplicationDbContext context):base(context)=> _context = context;
    //public async Task<CarWithImageAndCategoryResponse?> GetCarWithImageAsync(int id)
    //{
    //    return await _context.Cars
    //        .Where(c => c.Id == id)
    //        .Include(c=>c.CarImages)
    //        .ProjectToType<CarWithImageAndCategoryResponse>()
    //        .AsNoTracking()
    //        .FirstOrDefaultAsync();
     

    //}
    public async Task<IEnumerable<CarWithImageAndCategoryResponse>> GetCarWithCategoryAsync(int categoryId)
    {
      return await _context.Cars
            .Where (c => c.CategoryId == categoryId)
            .ProjectToType<CarWithImageAndCategoryResponse>()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<CarWithImageAndCategoryResponse>> GetCarWithImageAndCategoryAsync()
    {
        return await _context.Cars
             .Include(c => c.CarImages)
             .Include(c => c.Category)
             .ProjectToType<CarWithImageAndCategoryResponse>()
             .AsNoTracking()
             .ToListAsync();
        
    }
}
