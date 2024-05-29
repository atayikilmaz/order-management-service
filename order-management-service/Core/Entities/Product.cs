using System.ComponentModel.DataAnnotations;

namespace order_management_service.Core.Entities;

public class Product
{
    public int Id { get; set; }

    [Required]
    public int CompanyId { get; set; }

    public Company Company { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Range(0, int.MaxValue)]
    public int Stock { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }
}
