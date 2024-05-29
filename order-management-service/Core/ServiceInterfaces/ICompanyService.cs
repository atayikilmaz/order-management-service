using order_management_service.Dtos;

namespace order_management_service.Core.ServiceInterfaces;

public interface ICompanyService
{
    Task<IEnumerable<CompanyDto>> GetAllAsync();
    Task<CompanyDto> GetByIdAsync(int id);
    Task<CompanyDto> AddAsync(CompanyDto companyDto);
    Task UpdateOrderTimeAsync(int id, TimeSpan orderStartHour, TimeSpan orderEndHour);
    Task UpdateApprovalStatusAsync(int id, bool isApproved);
}
