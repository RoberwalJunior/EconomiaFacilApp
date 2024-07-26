using AutoMapper;
using EconomiaFacilApp.Libraries.Application.AutoMapper.Dtos.Usuarios;
using EconomiaFacilApp.Libraries.Application.Interfaces;
using EconomiaFacilApp.Libraries.Domain.Entities.Identity;
using EconomiaFacilApp.Libraries.Domain.Interfaces.Services;

namespace EconomiaFacilApp.Libraries.Application.ServiceApp;

public class UsuarioServiceApp(IMapper mapper, IUsuarioService service) : IUsuarioServiceApp
{
    private readonly IMapper mapper = mapper;
    private readonly IUsuarioService service = service;

    public async Task<string> Login(LoginUsuarioDto dto)
    {
        var usuario = await service.Login(dto.Email!, dto.Password!);
        return TokenServiceApp.GenereteToken(usuario);
    }

    public async Task Logout()
    {
        await service.Logout();
    }

    public async Task RegistrarUsuario(CreateUsuarioDto usuarioDto)
    {
        var usuario = mapper.Map<UsuarioComAcesso>(usuarioDto);
        await service.CadastrarUsuario(usuario, usuarioDto.Password!);
    }
}
