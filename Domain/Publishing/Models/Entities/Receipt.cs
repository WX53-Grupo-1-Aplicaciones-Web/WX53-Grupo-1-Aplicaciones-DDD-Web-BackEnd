namespace Domain.Publishing.Models.Entities;

public class Receipt : ModelBase
{
    public string Id { get; set; }
    public string ProductId { get; set; }
    public string Product { get; set; }
    //public Dictionary<string, string> Parameters { get; set; }
    public decimal Price { get; set; }
}
