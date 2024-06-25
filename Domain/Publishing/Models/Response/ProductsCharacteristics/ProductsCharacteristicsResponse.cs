using Domain.Publishing.Models.Entities.ProductsCharacteristics;

namespace Domain.Publishing.Models.Response.ProductsCharacteristics;

public class ProductsCharacteristicsResponse
{
    public int Id { get; set; }
    public List<Color> Colors { get; set; }
    public List<Size> Sizes { get; set; }
    public List<Material> Materials { get; set; }
    public List<Category> Categories { get; set; }
}