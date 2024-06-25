namespace Domain.Publishing.Models.Entities.ProductsCharacteristics;

public class ProductsCharacteristics
{
    public int Id { get; set; }
    public List<Color> Colors { get; set; }
    public List<Size> Sizes { get; set; }
    public List<Material> Materials { get; set; }
    public List<Category> Categories { get; set; }
}

