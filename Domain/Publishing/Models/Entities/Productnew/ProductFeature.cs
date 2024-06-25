namespace Domain.Publishing.Models.Entities.Productnew;

public class ProductFeature
{
    public int Id { get; set; } // Asegúrate de que esta propiedad existe
    public string Name { get; set; } // Asegúrate de que esta propiedad existe
    public string Description { get; set; } // Asegúrate de que esta propiedad existe
    public int ProductId { get; set; } // Agregar esta propiedad para la relación
}