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
public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private readonly ApplicationDbContext _context;
    public OrderRepository(ApplicationDbContext context):base(context)=>_context=context;
   
    public async Task<IEnumerable<OrderDetails>> GetOrderDetails()
    {
      return  await _context.Orders
            .Include(o=>o.Car)
            .Include(o=>o.User)
            .ProjectToType<OrderDetails>()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<OrderDetails>> GetOrderDetailsByUserId(string userId)
    {
       return await _context.Orders
            .Where(o=>o.UserId==userId)
            .ProjectToType<OrderDetails>()
            .AsNoTracking()
            .ToListAsync();
            
    }
}
