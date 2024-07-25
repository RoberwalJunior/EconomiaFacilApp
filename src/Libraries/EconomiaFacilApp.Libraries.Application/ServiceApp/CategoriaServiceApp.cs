using AutoMapper;
using EconomiaFacilApp.Libraries.Domain.Entities;
using EconomiaFacilApp.Libraries.Domain.Interfaces.Services;
using EconomiaFacilApp.Libraries.Application.Interfaces;
using EconomiaFacilApp.Libraries.Application.AutoMapper.Dtos.Categorias;

namespace EconomiaFacilApp.Libraries.Application.ServiceApp;

public class CategoriaServiceApp(IMapper mapper, ICategoriaService service) : ICategoriaServiceApp
{
    private readonly IMapper mapper = mapper;
    private readonly ICategoriaService service = service;

    public async Task<IEnumerable<ReadCategoriaDto>> ObterCategorias()
    {
        var categorias = await service.GetModelsAsync();
        return mapper.Map<IEnumerable<ReadCategoriaDto>>(categorias);
    }

    public ReadCategoriaDto? ObterCategoriaPeloId(int id)
    {
        var categoria = service.GetModelById(id);
        return categoria != null ? mapper.Map<ReadCategoriaDto>(categoria) : null;
    }

    public async Task<bool> CadastrarCategoria(CreateCategoriaDto categoriaDto)
    {
        var categoria = mapper.Map<Categoria>(categoriaDto);
        return await service.CreateModel(categoria);
    }

    public async Task<bool> AtualizarCategoria(int id, UpdateCategoriaDto categoriaDto)
    {
        var categoria = service.GetModelById(id);
        if (categoria == null) return false;
        mapper.Map(categoriaDto, categoria);
        return await service.UpdateModel(categoria);
    }

    public async Task<bool> ExcluirCategoria(int id)
    {
        return await service.DeleteModel(id);
    }
}
