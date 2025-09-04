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
public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    private readonly ApplicationDbContext _context;
    public CategoryRepository(ApplicationDbContext context):base(context)=>_context=context;
    
    public async Task<IEnumerable< CategoryWithCarResponse?>> GetCategoryWithCarAsync()
    {
        return await _context.Categories
             .Include(c => c.Cars)
             .ProjectToType<CategoryWithCarResponse>()
             .AsNoTracking()
             .ToListAsync();
    }
}
