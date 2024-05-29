using Microsoft.EntityFrameworkCore;
using order_management_service.Core.Entities;
using order_management_service.Core.Interfaces;

namespace order_management_service.Data.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly OrderManagementDbContext _context;

    public CompanyRepository(OrderManagementDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Company>> GetAllAsync()
    {
        return await _context.Companies.ToListAsync();
    }

    public async Task<Company> GetByIdAsync(int id)
    {
        return await _context.Companies.FindAsync(id);
    }

    public async Task AddAsync(Company company)
    {
        await _context.Companies.AddAsync(company);
    }

    public void Update(Company company)
    {
        _context.Companies.Update(company);
    }
}
