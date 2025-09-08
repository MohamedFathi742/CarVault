using CarVault.Application.DTOs.Requests;
using CarVault.Application.DTOs.Responses;
using CarVault.Application.Interfaces;
using CarVault.Domain.Entities;
using CarVault.Infrastructure.Common;
using CarVault.Infrastructure.Persistence;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace CarVault.Infrastructure.Repositories;
public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private readonly ApplicationDbContext _context;
    public OrderRepository(ApplicationDbContext context) : base(context) => _context = context;

    public async Task<IEnumerable<Order>> GetOrderDetails()
    {
        return await _context.Orders
              .Include(o => o.Car)
              .Include(o => o.User)
              .AsNoTracking()
              .ToListAsync();
    }

    public async Task<IEnumerable<Order>> GetOrderDetailsByUserId(string userId)
    {
        return await _context.Orders
             .Where(o => o.UserId == userId)
              .AsNoTracking()
             .ToListAsync();

    }

    public async Task<PaginationResponse<Order>> GetPagedAsync(OrderFilterRequest orderFilter)
    {
        IQueryable<Order> query = _context.Orders.AsNoTracking();

        if (orderFilter.FromDate.HasValue)
        {
            query = query.Where(o => o.OrderDate >= orderFilter.FromDate.Value);
        }

        if (orderFilter.ToDate.HasValue)
        {
            query = query.Where(o => o.OrderDate <= orderFilter.ToDate.Value);
        }
        if (!string.IsNullOrEmpty(orderFilter.Status))
        {
            query = query.Where(o => o.Status!=null&&o.Status.Contains(orderFilter.Status));

        }
        return await query.ToPagedResultAsync
            (
            orderFilter,
            searchPredicate: o => o.Status.ToLower().Contains(orderFilter.Search!)

            );
    }
}
