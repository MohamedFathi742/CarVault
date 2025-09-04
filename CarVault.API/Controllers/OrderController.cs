using CarVault.Application.DTOs.Requests;
using CarVault.Application.Services;
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
    var orders= await _service.GetAllOrdersAsync();
        return Ok(orders);
    
    }
    [HttpGet("details")]
    public async Task<IActionResult> OrderDetails()
    { 
    var orders= await _service.GetOrderDetailsAsync();
        return Ok(orders);
    
    }
    [HttpGet("details-by-user-{id}")]
    public async Task<IActionResult> GetOrderDetailsByUserId(string id)
    { 
    var orders= await _service.GetOrderDetailsByUserIdAsync(id);
        return Ok(orders);
    
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        var orders = await _service.GetOrderByIdAsync(id);
        return Ok(orders);

    }
    [HttpPost]
    public async Task<IActionResult> Add(CreateOrderRequest request)
    {
        var orders = await _service.AddOrderAsync(request);
        return Ok(orders);

    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(UpdateOrderRequest request,int id)
    {
        var orders = await _service.UpdateOrderAsync(request,id);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
         await _service.DeleteOrderAsync(id);
        return NoContent();
    }


}
