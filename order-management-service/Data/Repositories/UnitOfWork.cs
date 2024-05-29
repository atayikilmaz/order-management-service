using order_management_service.Core.Interfaces;

namespace order_management_service.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly OrderManagementDbContext _context;
    public ICompanyRepository Companies { get; private set; }
    public IProductRepository Products { get; private set; }
    public IOrderRepository Orders { get; private set; }

    public UnitOfWork(OrderManagementDbContext context, ICompanyRepository companyRepository, IProductRepository productRepository, IOrderRepository orderRepository)
    {
        _context = context;
        Companies = companyRepository;
        Products = productRepository;
        Orders = orderRepository;
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
