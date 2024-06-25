namespace Domain.Publishing.Models.Commands.ReceiptCommands;

public class CreateReceiptCommand
{
    public string ProductId { get; set; }
    public string Product { get; set; }
    //public Dictionary<string, string> Parameters { get; set; }
    public decimal Price { get; set; }
}
