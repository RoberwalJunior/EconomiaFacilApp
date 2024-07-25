using Microsoft.AspNetCore.Mvc;
using EconomiaFacilApp.Libraries.Application.Interfaces;
using EconomiaFacilApp.Libraries.Application.AutoMapper.Dtos.Categorias;

namespace EconomiaFacilApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController(ICategoriaServiceApp categoriaService) : ControllerBase
{
    private readonly ICategoriaServiceApp categoriaService = categoriaService;

    [HttpGet]
    public async Task<IActionResult> RecuperarCategorias()
    {
        return Ok(await categoriaService.ObterCategorias());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarCategoriaPeloId(int id)
    {
        var categoria = categoriaService.ObterCategoriaPeloId(id);
        return categoria != null ? Ok(categoria) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarCategoria([FromBody] CreateCategoriaDto categoriaDto)
    {
        await categoriaService.CadastrarCategoria(categoriaDto);
        return Ok("Categoria cadastrado com exito");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarCategoria(int id, [FromBody] UpdateCategoriaDto categoriaDto)
    {
        return await categoriaService.AtualizarCategoria(id, categoriaDto) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarCategoria(int id)
    {
        return await categoriaService.ExcluirCategoria(id) ? NoContent() : NotFound();
    }
}
