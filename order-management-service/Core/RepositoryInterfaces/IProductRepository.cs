using order_management_service.Core.Entities;

namespace order_management_service.Core.Interfaces;

public interface IProductRepository
{
    Task AddAsync(Product product);
}
