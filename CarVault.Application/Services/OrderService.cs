using CarVault.Application.DTOs.Requests;
using CarVault.Application.DTOs.Responses;
using CarVault.Application.Interfaces;
using CarVault.Domain.Entities;
using Mapster;

namespace CarVault.Application.Services;
public class OrderService(IOrderRepository repository ):IOrderService
{
    private readonly IOrderRepository _repository = repository;

    public async Task<IEnumerable<OrderResponse>> GetAllOrdersAsync()
    {
       var order= await _repository.GetAllAsync();
        return order.Adapt<IEnumerable<OrderResponse>>();
    }


    public async Task<IEnumerable<OrderDetilesResponse>> GetOrderDetailsAsync()
    {
       var order=await _repository.GetOrderDetails();
        return order.Adapt<IEnumerable<OrderDetilesResponse>>();
    }

    public async Task<IEnumerable<OrderDetilesResponse>> GetOrderDetailsByUserIdAsync(string userId)
    {
        var order=await _repository.GetOrderDetailsByUserId(userId);
        return order.Adapt<IEnumerable<OrderDetilesResponse>>();
    }

    public async Task<OrderResponse?> GetOrderByIdAsync(int id)
    {
       var order=await _repository.GetByIdAsync(id) ?? throw new Exception("Not found");
        return order.Adapt<OrderResponse>();
    }

    public async Task<OrderResponse?> AddOrderAsync(CreateOrderRequest request)
    {
       var order= request.Adapt<Order>();
       await _repository.AddAsync(order);

        return order.Adapt<OrderResponse>();
    }

    public async Task<OrderResponse?> UpdateOrderAsync(UpdateOrderRequest request, int id)
    {
        var order = await _repository.GetByIdAsync(id) ?? throw new Exception("Not found");
        order.Status=request.Status;
        await _repository.UpdateAsync(order);
        return order.Adapt<OrderResponse>();
    }

    public async Task DeleteOrderAsync(int id)
    {
        var order = await _repository.GetByIdAsync(id) ?? throw new Exception("Not found");
        await _repository.DeleteAsync(order);
    }

    public async Task<PaginationResponse<OrderResponse>> GetPagedAsync(OrderFilterRequest orderFilter)
    {
       var result=await _repository.GetPagedAsync(orderFilter);
        return result.Adapt<PaginationResponse<OrderResponse>>();
    }
}
