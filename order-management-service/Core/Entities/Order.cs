using System.ComponentModel.DataAnnotations;

namespace order_management_service.Core.Entities;

public class Order
{
    public int Id { get; set; }

    [Required]
    public int CompanyId { get; set; }

    public Company Company { get; set; }

    [Required]
    public int ProductId { get; set; }

    public Product Product { get; set; }

    [Required]
    [MaxLength(100)]
    public string CustomerName { get; set; }

    [Required]
    public DateTime OrderDate { get; set; }
}
