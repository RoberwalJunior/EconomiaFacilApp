using System.ComponentModel.DataAnnotations;

namespace EconomiaFacilApp.Libraries.Application.AutoMapper.Dtos.Despesas;

public class CreateDespesaDto
{
    [Required]
    public int UsuarioId { get; set; }

    [Required]
    public int CategoriaId { get; set; }

    [Required]
    [StringLength(200)]
    public string? Descricao { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DataPagamento { get; set; }

    [Required]
    public decimal Valor { get; set; }

    [Required]
    public int FormaPagamento { get; set; }

    [StringLength(200)]
    public string? ComprovanteImagem { get; set; }
}
