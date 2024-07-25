using System.ComponentModel.DataAnnotations;
using EconomiaFacilApp.Libraries.Domain.Entities.Enums;

namespace EconomiaFacilApp.Libraries.Domain.Entities;

public class Categoria
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string? Nome { get; set; }

    [Required]
    public TipoCategoria Tipo { get; set; }

    [Required]
    public bool HabilitarLimite { get; set; }

    [Required]
    public decimal Limite { get; set; }

    public virtual ICollection<Despesa>? Despesas { get; set; }
}
