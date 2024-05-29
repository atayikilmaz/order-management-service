using order_management_service.Core.Entities;
using order_management_service.Core.Interfaces;

namespace order_management_service.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly OrderManagementDbContext _context;

    public ProductRepository(OrderManagementDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }
}
