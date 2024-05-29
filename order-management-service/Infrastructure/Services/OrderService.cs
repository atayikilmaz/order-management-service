using AutoMapper;
using order_management_service.Core.Entities;
using order_management_service.Core.Interfaces;
using order_management_service.Core.ServiceInterfaces;
using order_management_service.Dtos;

namespace order_management_service.Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<string> CreateOrderAsync(OrderDto orderDto)
    {
        var company = await _unitOfWork.Companies.GetByIdAsync(orderDto.CompanyId);
        if (company == null || !company.IsApproved)
        {
            return "Firma Onaylı Değil";
        }

        var currentHour = orderDto.OrderDate.TimeOfDay;
        if (currentHour < company.OrderStartHour || currentHour > company.OrderEndHour)
        {
            return "Firma şu an sipariş almıyor";
        }

        var order = _mapper.Map<Order>(orderDto);
        await _unitOfWork.Orders.AddAsync(order);
        await _unitOfWork.CompleteAsync();

        return "Sipariş başarıyla oluşturuldu";
    }
}
