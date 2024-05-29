using AutoMapper;
using order_management_service.Core.Entities;
using order_management_service.Dtos;

namespace order_management_service.Infrastructure.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Company, CompanyDto>()
            .ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Order, OrderDto>().ReverseMap();
    }
}
