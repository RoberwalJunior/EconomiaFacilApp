using Microsoft.AspNetCore.Mvc;
using EconomiaFacilApp.Libraries.Application.Interfaces;
using EconomiaFacilApp.Libraries.Application.AutoMapper.Dtos.Usuarios;

namespace EconomiaFacilApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController(IUsuarioServiceApp usuarioService) : ControllerBase
{
    private readonly IUsuarioServiceApp service = usuarioService;

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginUsuarioDto dto)
    {
        return Ok(await service.Login(dto));
    }

    [HttpPost("Logout")]
    public async Task<IActionResult> Logout()
    {
        await service.Logout();
        return Ok("Usuário Deslogado com sucesso!");
    }

    [HttpPost("Registrar")]
    public async Task<IActionResult> RegistrarNovoUsuario([FromBody] CreateUsuarioDto usuarioDto)
    {
        await service.RegistrarUsuario(usuarioDto);
        return Ok("Usuario cadastrado com exito!");
    }
}
