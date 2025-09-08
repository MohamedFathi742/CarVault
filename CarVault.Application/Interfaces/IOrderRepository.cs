using CarVault.Application.DTOs.Requests;
using CarVault.Application.DTOs.Responses;
using CarVault.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Application.Interfaces;
public interface IOrderRepository:IGenericRepository<Order>
{
    Task<IEnumerable<Order>> GetOrderDetails();
    Task<IEnumerable<Order>> GetOrderDetailsByUserId(string userId);
    Task<PaginationResponse<Order>> GetPagedAsync(OrderFilterRequest orderFilter);

}
