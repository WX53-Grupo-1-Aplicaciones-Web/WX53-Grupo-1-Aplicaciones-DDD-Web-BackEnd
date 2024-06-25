using System.ComponentModel.DataAnnotations;
using Domain.Publishing.Models.Entities.Productnew;

namespace Domain.Publishing.Models.Commands.ProductnewComands;

public class UpdateProductnewCommand
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public string Details { get; set; }
        
    [Required]
    public string ArtisanDetails { get; set; }

    [Required]
    public PersonalizationParameter PersonalizationParameter { get; set; }
        
    [Required]
    public int Size { get; set; }
        
    [Required]
    public string InputText { get; set; }
        
    [Required]
    public string Engraving { get; set; }
        
    [Required]
    public string Category { get; set; }
        
    [Required]
    public string Image { get; set; }
        
    [Required]
    public List<string> DetailImages { get; set; }
        
    [Required]
    public string Author { get; set; }
        
    [Required]
    public List<ProductFeature> Characteristics { get; set; }
}