using order_management_service.Dtos;

namespace order_management_service.Core.ServiceInterfaces;

public interface IProductService
{
    Task<ProductDto> AddAsync(ProductDto productDto);
}
