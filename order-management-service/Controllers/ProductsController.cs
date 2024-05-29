using Microsoft.AspNetCore.Mvc;
using order_management_service.Core.ServiceInterfaces;
using order_management_service.Dtos;

namespace order_management_service.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> Add(ProductDto productDto)
    {
        var product = await _productService.AddAsync(productDto);
        return Ok(product);
    }
}
