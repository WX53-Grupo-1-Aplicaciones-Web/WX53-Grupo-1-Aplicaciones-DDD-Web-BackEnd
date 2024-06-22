using System.ComponentModel.DataAnnotations;

namespace Domain.Publishing.Models.Commands.CustomerCommands;

public record SignUpCommand
{
    [Required]public string Usuario { get; set; }
    [Required]public string Contraseña { get; set; }
    [Required]public string Correo { get; set; }
    public string? ImagenUsuario { get; set; }
    [Required] public bool IsArtisan { get; set; }
    public string? Role{ get; set; }
}

