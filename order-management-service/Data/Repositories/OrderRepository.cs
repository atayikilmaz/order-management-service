using order_management_service.Core.Entities;
using order_management_service.Core.Interfaces;

namespace order_management_service.Data.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly OrderManagementDbContext _context;

    public OrderRepository(OrderManagementDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
    }
}
