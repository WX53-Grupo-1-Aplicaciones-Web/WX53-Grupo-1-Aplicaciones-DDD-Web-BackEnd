namespace Domain.Publishing.Models.Commands.CustomerCommands;

public class CreateProductsCharacteristicsCommand
{
    public List<int> ColorId { get; set; }
    public List<int> SizeId { get; set; }
    public List<int> MaterialId { get; set; }
    public List<int> CategoryId { get; set; }
}