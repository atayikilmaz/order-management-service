using order_management_service.Dtos;

namespace order_management_service.Core.ServiceInterfaces;

public interface IOrderService
{
    Task<string> CreateOrderAsync(OrderDto orderDto);
}
