using EconomiaFacilApp.Libraries.Application.AutoMapper.Dtos.Usuarios;

namespace EconomiaFacilApp.Libraries.Application.Interfaces;

public interface IUsuarioServiceApp
{
    public Task<ReadTokenDto> Login(LoginUsuarioDto dto);
    public Task Logout();
    public Task RegistrarUsuario(CreateUsuarioDto usuarioDto);
}
