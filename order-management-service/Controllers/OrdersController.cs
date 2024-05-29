using Microsoft.AspNetCore.Mvc;
using order_management_service.Core.ServiceInterfaces;
using order_management_service.Dtos;

namespace order_management_service.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(OrderDto orderDto)
    {
        var result = await _orderService.CreateOrderAsync(orderDto);
        return Ok(result);
    }
}
