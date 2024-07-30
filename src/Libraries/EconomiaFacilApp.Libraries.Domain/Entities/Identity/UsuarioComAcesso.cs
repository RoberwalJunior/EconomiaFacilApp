using Microsoft.AspNetCore.Identity;

namespace EconomiaFacilApp.Libraries.Domain.Entities.Identity;

public class UsuarioComAcesso : IdentityUser<int>
{
    public virtual ICollection<Categoria>? Categorias { get; set; }
    public virtual ICollection<Despesa>? Despesas { get; set; }
}
