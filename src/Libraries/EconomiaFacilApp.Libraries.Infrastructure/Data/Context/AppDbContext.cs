using Microsoft.EntityFrameworkCore;
using EconomiaFacilApp.Libraries.Domain.Entities;

namespace EconomiaFacilApp.Libraries.Infrastructure.Data.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Despesa> Despesas { get; set; }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<decimal>()
            .HavePrecision(18, 6);
    }
}
