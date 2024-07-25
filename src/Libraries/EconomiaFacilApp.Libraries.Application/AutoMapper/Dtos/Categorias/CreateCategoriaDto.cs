using System.ComponentModel.DataAnnotations;

namespace EconomiaFacilApp.Libraries.Application.AutoMapper.Dtos.Categorias;

public class CreateCategoriaDto
{
    [Required]
    [StringLength(100)]
    public string? Nome { get; set; }

    [Required]
    public int Tipo { get; set; }

    [Required]
    public bool HabilitarLimite { get; set; }

    [Required]
    public decimal Limite { get; set; }
}
