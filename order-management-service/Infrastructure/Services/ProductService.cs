using AutoMapper;
using order_management_service.Core.Entities;
using order_management_service.Core.Interfaces;
using order_management_service.Core.ServiceInterfaces;
using order_management_service.Dtos;

namespace order_management_service.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ProductDto> AddAsync(ProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _unitOfWork.Products.AddAsync(product);
        await _unitOfWork.CompleteAsync(); 
        
        return _mapper.Map<ProductDto>(product);

    }
}
