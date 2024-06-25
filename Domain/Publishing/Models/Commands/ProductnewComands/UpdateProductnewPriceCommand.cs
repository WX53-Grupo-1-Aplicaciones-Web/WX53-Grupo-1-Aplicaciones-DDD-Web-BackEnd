using System.ComponentModel.DataAnnotations;

namespace Domain.Publishing.Models.Commands.ProductComands;

public class UpdateProductnewPriceCommand
{
    [Required]
    public int Id { get; set; }

    [Required]
    public decimal Price { get; set; }
}