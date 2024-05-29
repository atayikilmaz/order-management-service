namespace order_management_service.Dtos;

public class OrderDto
{
    public int CompanyId { get; set; }
    public int ProductId { get; set; }
    public string CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
}
