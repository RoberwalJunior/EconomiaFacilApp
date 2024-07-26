using EconomiaFacilApp.Libraries.Domain.Entities.Identity;

namespace EconomiaFacilApp.Libraries.Application.Interfaces;

public interface ITokenServiceApp
{
    public string GenereteToken(UsuarioComAcesso usuario);
}
