using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using order_management_service.Core.Entities;
using order_management_service.Core.Interfaces;
using order_management_service.Core.ServiceInterfaces;
using order_management_service.Dtos;

namespace order_management_service.Infrastructure.Services;

public class CompanyService : ICompanyService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CompanyService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CompanyDto>> GetAllAsync()
    {
        var companies = await _unitOfWork.Companies.GetAllAsync();
        return _mapper.Map<IEnumerable<CompanyDto>>(companies);
    }

    public async Task<CompanyDto> GetByIdAsync(int id)
    {
        var company = await _unitOfWork.Companies.GetByIdAsync(id);
        return _mapper.Map<CompanyDto>(company);
    }

    public async Task<CompanyDto> AddAsync(CompanyDto companyDto)
    {
        var company = _mapper.Map<Company>(companyDto);
        await _unitOfWork.Companies.AddAsync(company);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<CompanyDto>(company);
    }

    public async Task UpdateOrderTimeAsync(int id, TimeSpan orderStartHour, TimeSpan orderEndHour)
    {
        var company = await _unitOfWork.Companies.GetByIdAsync(id);
        if (company != null)
        {
            company.OrderStartHour = orderStartHour;
            company.OrderEndHour = orderEndHour;
            _unitOfWork.Companies.Update(company);
            await _unitOfWork.CompleteAsync();
            
        }

    }

    public async Task UpdateApprovalStatusAsync(int id, bool isApproved)
    {
        var company = await _unitOfWork.Companies.GetByIdAsync(id);
        if (company != null)
        {
            company.IsApproved = isApproved;
            _unitOfWork.Companies.Update(company);
            await _unitOfWork.CompleteAsync();
        }

    }
}
