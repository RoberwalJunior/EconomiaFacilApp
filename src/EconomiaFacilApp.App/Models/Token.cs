namespace EconomiaFacilApp.App.Models;

public class Token
{
    public string? ChaveToken { get; set; }
    public string? TipoToken { get; set; }
    public int UsuarioId { get; set; }
    public string? UsuarioUserName { get; set; }
    public string? UsuarioEmail { get; set; }
}
