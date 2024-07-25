using Microsoft.AspNetCore.Mvc;
using EconomiaFacilApp.Libraries.Application.Interfaces;
using EconomiaFacilApp.Libraries.Application.AutoMapper.Dtos.Despesas;

namespace EconomiaFacilApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DespesasController(IDespesaServiceApp despesaService) : ControllerBase
{
    private readonly IDespesaServiceApp despesaService = despesaService;

    [HttpGet]
    public async Task<IActionResult> RecuperarDespesas()
    {
        return Ok(await despesaService.ObterDespesas());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarDespesaPeloId(int id)
    {
        var despesa = despesaService.ObterDespesaPeloId(id);
        return despesa != null ? Ok(despesa) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarDespesa([FromBody] CreateDespesaDto despesaDto)
    {
        await despesaService.CadastrarDespesa(despesaDto);
        return Ok("Despesa cadastrado com exito");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarDespesa(int id, [FromBody] UpdateDespesaDto despesaDto)
    {
        return await despesaService.AtualizarDespesa(id, despesaDto) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarDespesa(int id)
    {
        return await despesaService.ExcluirDespesa(id) ? NoContent() : NotFound();
    }
}
