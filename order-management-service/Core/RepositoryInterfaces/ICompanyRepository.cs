using order_management_service.Core.Entities;

namespace order_management_service.Core.Interfaces;

public interface ICompanyRepository
{
    Task<IEnumerable<Company>> GetAllAsync();
    Task<Company> GetByIdAsync(int id);
    Task AddAsync(Company company);
    void Update(Company company);
}
