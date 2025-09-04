using CarVault.Application.DTOs.Requests;
using CarVault.Application.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Application.Services;
public interface IOrderService
{

    Task<IEnumerable<OrderResponse>> GetAllOrdersAsync();
    Task<IEnumerable<OrderDetails>> GetOrderDetailsAsync();
    Task<IEnumerable<OrderDetails>> GetOrderDetailsByUserIdAsync(string userId);
    Task<OrderResponse?> GetOrderByIdAsync(int id);
    Task<OrderResponse?> AddOrderAsync(CreateOrderRequest request);
    Task<OrderResponse?> UpdateOrderAsync(UpdateOrderRequest request, int id);
    Task DeleteOrderAsync(int id);



}
