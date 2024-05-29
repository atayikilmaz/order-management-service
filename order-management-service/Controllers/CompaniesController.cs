using Microsoft.AspNetCore.Mvc;
using order_management_service.Core.ServiceInterfaces;
using order_management_service.Dtos;

namespace order_management_service.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompaniesController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var companies = await _companyService.GetAllAsync();
        return Ok(companies);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CompanyDto companyDto)
    {
        TimeSpan orderStartHour = TimeSpan.Parse(companyDto.OrderStartHour);
        TimeSpan orderEndHour = TimeSpan.Parse(companyDto.OrderEndHour);

        companyDto.OrderStartHour = orderStartHour.ToString();
        companyDto.OrderEndHour = orderEndHour.ToString();

        var company = await _companyService.AddAsync(companyDto);
        return Ok(company);
    }

    [HttpPut("{id}/OrderTime")]
    public async Task<IActionResult> UpdateOrderTime(int id, [FromBody] UpdateOrderTimeDto updateOrderTimeDto)
    {
        TimeSpan orderStartHour = TimeSpan.Parse(updateOrderTimeDto.OrderStartHour);
        TimeSpan orderEndHour = TimeSpan.Parse(updateOrderTimeDto.OrderEndHour);

        await _companyService.UpdateOrderTimeAsync(id, orderStartHour, orderEndHour);
        return Ok("Başarıyla güncellendi");
    }

    [HttpPut("{id}/ApprovalStatus")]
    public async Task<IActionResult> UpdateApprovalStatus(int id, [FromBody] bool isApproved)
    {
        await _companyService.UpdateApprovalStatusAsync(id, isApproved);
        return Ok("Başarıyla güncellendi");
    }
}
