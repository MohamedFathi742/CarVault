using CarVault.Application.DTOs.Requests;
using CarVault.Application.DTOs.Responses;
using CarVault.Application.Interfaces;
using CarVault.Domain.Entities;
using CarVault.Infrastructure.Common;
using CarVault.Infrastructure.Persistence;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace CarVault.Infrastructure.Repositories;
public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    private readonly ApplicationDbContext _context;
    public CategoryRepository(ApplicationDbContext context):base(context)=>_context=context;
    
    public async Task<IEnumerable<Category?>> GetCategoryWithCarAsync()
    {
        return await _context.Categories
             .Include(c => c.Cars)
             .AsNoTracking()
             .ToListAsync();
    }

    public async Task<PaginationResponse<Category>> GetPagedAsync(CategoryFilterRequest categoryFilter)
    {
     IQueryable<Category> query = _context.Categories.AsNoTracking();

        if (!string.IsNullOrEmpty(categoryFilter.Name))
        {
            query = query.Where(c => c.Name != null && c.Name.Contains(categoryFilter.Name));
        }

        return await query.ToPagedResultAsync
            (
            categoryFilter,
            searchPredicate: c => c.Name.ToLower().Contains(categoryFilter.Search!)

            );

    }
}
