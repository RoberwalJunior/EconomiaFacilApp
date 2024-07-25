namespace EconomiaFacilApp.Libraries.Application.AutoMapper.Dtos.Despesas;

public class ReadDespesaDto
{
    public int CategoriaId { get; set; }
    public string? Descricao { get; set; }
    public DateTime DataPagamento { get; set; }
    public decimal Valor { get; set; }
    public string? FormaPagamento { get; set; }
    public string? ComprovanteImagem { get; set; }
}
