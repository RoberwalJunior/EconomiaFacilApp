using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using EconomiaFacilApp.Libraries.Application.Interfaces;
using EconomiaFacilApp.Libraries.Domain.Entities.Identity;

namespace EconomiaFacilApp.Libraries.Application.ServiceApp;

public class TokenServiceApp(IConfiguration configuration) : ITokenServiceApp
{
    private readonly IConfiguration configuration = configuration;

    public string GenereteToken(UsuarioComAcesso usuario)
    {
        var claims = new Claim[]
        {
            new(ClaimTypes.Email, usuario.Email!),
            new(ClaimTypes.Name, usuario.UserName!)
        };

        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]!));
        var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken
            (
                issuer: configuration["JWT:Issuer"],
                audience: configuration["JWT:Audience"],
                expires: DateTime.Now.AddHours(2),
                claims: claims,
                signingCredentials: signingCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
