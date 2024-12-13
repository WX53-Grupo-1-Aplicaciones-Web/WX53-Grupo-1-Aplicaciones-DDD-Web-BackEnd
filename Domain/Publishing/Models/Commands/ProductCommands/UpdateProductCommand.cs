namespace Domain.Publishing.Models.Commands.ProductCommands;

public class UpdateProductCommand
{
      public string? Nombre { get; set; }
      public string? Imagen { get; set; }
      public string? Descripcion { get; set; }
}