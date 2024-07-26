using System.ComponentModel.DataAnnotations;

namespace EconomiaFacilApp.Libraries.Application.AutoMapper.Dtos.Usuarios;

public class CreateUsuarioDto
{
    [Required]
    public string? UserName { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Required]
    [Compare(nameof(Password))]
    public string? RePassword { get; set; }
}
