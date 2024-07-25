using Microsoft.EntityFrameworkCore;
using EconomiaFacilApp.Libraries.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EconomiaFacilApp.Libraries.Infrastructure.Data.Modelos;

namespace EconomiaFacilApp.Libraries.Infrastructure.Data.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) 
    : IdentityDbContext<UsuarioComAcesso, PerfilDeAcesso, int>(options)
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Despesa> Despesas { get; set; }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<decimal>()
            .HavePrecision(18, 6);
    }
}
