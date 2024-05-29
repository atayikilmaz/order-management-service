using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace order_management_service.Dtos;

public class UpdateOrderTimeDto
{
    //swagger'da hh:mm:ss formatında olması gerektiğini göstermek için
    [Required]
    [RegularExpression(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$", ErrorMessage = "Geçersiz zaman formatı. 'hh:mm:ss' formatını kullanın.")]
    [DefaultValue("09:00:00")]
    public string OrderStartHour { get; set; }

    [Required]
    [RegularExpression(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$", ErrorMessage = "Geçersiz zaman formatı. 'hh:mm:ss' formatını kullanın.")]
    [DefaultValue("18:00:00")]
    public string OrderEndHour { get; set; }

}