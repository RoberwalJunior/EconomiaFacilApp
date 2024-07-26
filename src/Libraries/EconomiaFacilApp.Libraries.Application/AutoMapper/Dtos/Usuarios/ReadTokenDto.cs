namespace EconomiaFacilApp.Libraries.Application.AutoMapper.Dtos.Usuarios;

public class ReadTokenDto
{
    public string? ChaveToken { get; set; }
    public string? TipoToken { get; set; }
    public int UsuarioId { get; set; }
    public string? UsuarioUserName { get; set; }
    public string? UsuarioEmail { get; set; }
}
