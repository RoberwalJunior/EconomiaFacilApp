using EconomiaFacilApp.Libraries.Application.AutoMapper.Dtos.Categorias;

namespace EconomiaFacilApp.Libraries.Application.Interfaces;

public interface ICategoriaServiceApp
{
    public Task<IEnumerable<ReadCategoriaDto>> ObterCategorias();
    public ReadCategoriaDto? ObterCategoriaPeloId(int id);
    public Task<bool> CadastrarCategoria(CreateCategoriaDto categoriaDto);
    public Task<bool> AtualizarCategoria(UpdateCategoriaDto categoriaDto);
    public Task<bool> ExcluirCategoria(int id);
}
