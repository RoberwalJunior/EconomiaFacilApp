namespace EconomiaFacilApp.Libraries.Application.AutoMapper.Dtos.Categorias;

public class ReadCategoriaDto
{
    public string? Nome { get; set; }
    public string? Tipo { get; set; }
    public bool HabilitarLimite { get; set; }
    public decimal Limite { get; set; }
}
