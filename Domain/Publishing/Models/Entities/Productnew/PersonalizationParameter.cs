namespace Domain.Publishing.Models.Entities.Productnew;

public class PersonalizationParameter
{
    public int ProductId { get; set; } // Agregar esta propiedad
    public List<string> Colors { get; set; }
    public List<string> Materials { get; set; }
    public List<string> Sizes { get; set; }
    public string Engraving { get; set; }
}