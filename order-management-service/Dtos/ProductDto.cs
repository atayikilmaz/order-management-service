namespace order_management_service.Dtos;

public class ProductDto
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
}
