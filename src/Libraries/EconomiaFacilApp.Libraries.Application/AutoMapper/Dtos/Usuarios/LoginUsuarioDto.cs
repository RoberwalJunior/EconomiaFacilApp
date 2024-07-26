using System.ComponentModel.DataAnnotations;

namespace EconomiaFacilApp.Libraries.Application.AutoMapper.Dtos.Usuarios;

public class LoginUsuarioDto
{
    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }
}
