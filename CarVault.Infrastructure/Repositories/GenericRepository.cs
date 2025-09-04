using CarVault.Application.Interfaces;
using CarVault.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarVault.Infrastructure.Repositories;
public class GenericRepository<T>(ApplicationDbContext context) : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context = context;
    private readonly DbSet<T> _dbSet = context.Set<T>();
    public async Task<IEnumerable<T>> GetAllAsync()=>await _dbSet.ToListAsync();
    

    public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
   
    public async Task AddAsync(T entity)
    {
       await _dbSet.AddAsync(entity);
         _context.SaveChanges();
    }

    public async Task UpdateAsync(T entity)
    {
       _dbSet.Update( entity);
       await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
           await _context.SaveChangesAsync();

    }





}
