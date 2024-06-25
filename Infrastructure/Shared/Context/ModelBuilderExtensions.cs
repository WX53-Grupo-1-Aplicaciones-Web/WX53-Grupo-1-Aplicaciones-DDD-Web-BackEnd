namespace Infrastructure.Shared.Context;
using Microsoft.EntityFrameworkCore;
using Domain.Publishing.Models.Entities.ProductsCharacteristics;


public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Color>().HasData(
            new Color { Id = 1, Name = "rojo" },
            new Color { Id = 2, Name = "verde" },
            new Color { Id = 3, Name = "amarillo" },
            new Color { Id = 4, Name = "azul" },
            new Color { Id = 5, Name = "anaranjado" },
            new Color { Id = 6, Name = "morado" },
            new Color { Id = 7, Name = "marron" },
            new Color { Id = 8, Name = "celeste" },
            new Color { Id = 9, Name = "negro" },
            new Color { Id = 10, Name = "rosado" }
        );

        modelBuilder.Entity<Size>().HasData(
            new Size { Id = 1, Name = "pequeño" },
            new Size { Id = 2, Name = "mediano" },
            new Size { Id = 3, Name = "grande" }
        );

        modelBuilder.Entity<Material>().HasData(
            new Material { Id = 1, Name = "madera" },
            new Material { Id = 2, Name = "tela" },
            new Material { Id = 3, Name = "ceramica" },
            new Material { Id = 4, Name = "acero" },
            new Material { Id = 5, Name = "vidrio" },
            new Material { Id = 6, Name = "barro" },
            new Material { Id = 7, Name = "cestería" }
        );

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Joyería artesanal" },
            new Category { Id = 2, Name = "Textiles y tejidos" },
            new Category { Id = 3, Name = "Cerámica y alfarería" },
            new Category { Id = 4, Name = "Artesanía en madera" },
            new Category { Id = 5, Name = "Artesanía en cuero" },
            new Category { Id = 6, Name = "Arte visual" },
            new Category { Id = 7, Name = "Cuidado personal" },
            new Category { Id = 8, Name = "Juguetes" },
            new Category { Id = 9, Name = "Decoración del hogar" },
            new Category { Id = 10, Name = "Productos gastronómicos artesanales" }
        );
    }
}