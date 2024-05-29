using System.ComponentModel.DataAnnotations;

namespace order_management_service.Core.Entities;

public class Company
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public bool IsApproved { get; set; }

    [Required]
    public TimeSpan OrderStartHour { get; set; }

    [Required]
    public TimeSpan OrderEndHour { get; set; }

    public ICollection<Product> Products { get; set; }
}