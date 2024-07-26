using AutoMapper;
using EconomiaFacilApp.Libraries.Application.Interfaces;
using EconomiaFacilApp.Libraries.Application.AutoMapper.Dtos.Usuarios;
using EconomiaFacilApp.Libraries.Domain.Entities.Identity;
using EconomiaFacilApp.Libraries.Domain.Interfaces.Services;

namespace EconomiaFacilApp.Libraries.Application.ServiceApp;

public class UsuarioServiceApp(IMapper mapper, IUsuarioService service,
    ITokenServiceApp tokenService) : IUsuarioServiceApp
{
    private readonly IMapper mapper = mapper;
    private readonly IUsuarioService service = service;
    private readonly ITokenServiceApp tokenService = tokenService;

    public async Task<string> Login(LoginUsuarioDto dto)
    {
        var usuario = await service.Login(dto.Email!, dto.Password!);
        return tokenService.GenereteToken(usuario);
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
