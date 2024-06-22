using System.ComponentModel.DataAnnotations;

namespace Domain.Publishing.Models.Commands.CustomerCommands;

public class CreateCustomerCommand
{
    [Required]public string Usuario { get; set; }
    [Required]public string Contraseña { get; set; }
    [Required]public string Correo { get; set; }
    [Required]public string ImagenUsuario { get; set; }
}