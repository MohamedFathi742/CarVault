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
    Task<IEnumerable<OrderDetails>> GetOrderDetails();
    Task<IEnumerable<OrderDetails>> GetOrderDetailsByUserId(string userId);


}
