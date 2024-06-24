using System.ComponentModel.DataAnnotations;

namespace Domain.Publishing.Models.Commands.OrderCommands;

public class CreateOrderCommand
{
    [Required]
    public string ProductId { get; set; }
    public string Product { get; set; }
    public List<OrderParameterCommand> Parameters { get; set; }
    public decimal Price { get; set; }
}