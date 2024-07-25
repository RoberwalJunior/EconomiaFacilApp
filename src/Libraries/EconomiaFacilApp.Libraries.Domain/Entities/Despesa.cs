using System.ComponentModel.DataAnnotations;
using EconomiaFacilApp.Libraries.Domain.Entities.Enums;

namespace EconomiaFacilApp.Libraries.Domain.Entities;

public class Despesa
{
    public int Id { get; set; }

    public int CategoriaId { get; set; }
    public virtual Categoria? Categoria { get; set; }

    [Required]
    [StringLength(200)]
    public string? Descricao { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DataPagamento { get; set; }

    [Required]
    public decimal Valor { get; set; }

    [Required]
    public TipoPagamento FormaPagamento { get; set; }

    [StringLength(200)]
    public string? ComprovanteImagem { get; set; }
}
