using Microsoft.AspNetCore.Identity;
using EconomiaFacilApp.Libraries.Domain.Entities.Identity;
using EconomiaFacilApp.Libraries.Domain.Interfaces.Services;

namespace EconomiaFacilApp.Libraries.Domain.Services;

public class UsuarioService(UserManager<UsuarioComAcesso> userManager,
    SignInManager<UsuarioComAcesso> singInManager) : IUsuarioService
{
    private readonly UserManager<UsuarioComAcesso> userManager = userManager;
    private readonly SignInManager<UsuarioComAcesso> singInManager = singInManager;

    public async Task CadastrarUsuario(UsuarioComAcesso usuario, string password)
    {
        var result = await userManager.CreateAsync(usuario, password);

        if (!result.Succeeded)
        {
            throw new ApplicationException("Falha ao cadastrar usuário!");
        }
    }

    public async Task<UsuarioComAcesso> Login(string email, string password)
    {
        var usuario = await userManager.FindByEmailAsync(email) ?? throw new ApplicationException("E-mail incorreto!");
        var result = await singInManager.PasswordSignInAsync(usuario.UserName, password, false, false);
        if (!result.Succeeded)
        {
            throw new ApplicationException("Usuário não autenticado!");
        }

        return singInManager
            .UserManager
            .Users
            .FirstOrDefault(user => user.NormalizedUserName!.Equals(usuario.UserName!.ToUpper()))!;
    }

    public async Task Logout()
    {
        await singInManager.SignOutAsync();
    }
}
