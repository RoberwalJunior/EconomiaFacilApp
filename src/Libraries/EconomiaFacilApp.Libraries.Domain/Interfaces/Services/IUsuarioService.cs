using EconomiaFacilApp.Libraries.Domain.Entities.Identity;

namespace EconomiaFacilApp.Libraries.Domain.Interfaces.Services;

public interface IUsuarioService
{
    public Task CadastrarUsuario(UsuarioComAcesso usuario, string password);
    public Task<UsuarioComAcesso> Login(string email, string password);
    public Task Logout();
}
