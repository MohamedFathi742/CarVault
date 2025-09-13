using CarVault.Application.DTOs.Requests;
using CarVault.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarVault.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrderController(IOrderService service) : ControllerBase
{
    private readonly IOrderService _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orders = await _service.GetAllOrdersAsync();
        return Ok(orders);
    }

    [HttpGet("pagination")]
    public async Task<IActionResult> Pagination([FromQuery] OrderFilterRequest request)
    {
        var orders = await _service.GetPagedAsync(request);
        return Ok(orders);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("details")]
    public async Task<IActionResult> OrderDetails()
    {
        var orders = await _service.GetOrderDetailsAsync();
        return Ok(orders);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("details-by-user/{userId}")]
    public async Task<IActionResult> GetOrderDetailsByUserId(string userId)
    {
        var orders = await _service.GetOrderDetailsByUserIdAsync(userId);
        return Ok(orders);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        var order = await _service.GetOrderByIdAsync(id);
        return Ok(order);
    }

    

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateOrderRequest request)
    {
        var order = await _service.AddOrderAsync(request);
        return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromBody] UpdateOrderRequest request, int id)
    {
        var updatedOrder = await _service.UpdateOrderAsync(request, id);
        return Ok(updatedOrder); 
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteOrderAsync(id);
        return Ok(new { Message = "Order deleted successfully" });
    }
}

