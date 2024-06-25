namespace Domain.Publishing.Models.Entities.Productnew;

public class Productnew : ModelBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Details { get; set; }
    public string ArtisanDetails { get; set; }
    public PersonalizationParameter PersonalizationParameter { get; set; }
    public int Size { get; set; }
    public string InputText { get; set; }
    public string Engraving { get; set; }
    public string Category { get; set; }
    public string Image { get; set; }
    public List<string> DetailImages { get; set; }
    public string Author { get; set; }
    public List<ProductFeature> Features  { get; set; }
}