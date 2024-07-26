using EconomiaFacilApp.Libraries.Domain.Entities.Identity;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace EconomiaFacilApp.Libraries.Application.ServiceApp;

public static class TokenServiceApp
{
    public static string GenereteToken(UsuarioComAcesso usuario)
    {
        var claims = new Claim[]
        {
            new(ClaimTypes.Email, usuario.Email!),
            new(ClaimTypes.Name, usuario.UserName!)
        };

        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("wuigdiwqgfiqgwfuiqgyi1gwi1gfiy2f1ffd12fd1"));

        var signingCredentials = new SigningCredentials(chave,
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken
            (
                expires: DateTime.Now.AddMinutes(10),
                claims: claims,
                signingCredentials: signingCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
