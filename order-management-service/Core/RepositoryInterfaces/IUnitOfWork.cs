namespace order_management_service.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ICompanyRepository Companies { get; }
    IProductRepository Products { get; }
    IOrderRepository Orders { get; }
    Task<int> CompleteAsync();
}
