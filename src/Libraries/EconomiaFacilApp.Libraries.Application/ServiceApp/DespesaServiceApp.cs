using AutoMapper;
using EconomiaFacilApp.Libraries.Application.AutoMapper.Dtos.Despesas;
using EconomiaFacilApp.Libraries.Application.Interfaces;
using EconomiaFacilApp.Libraries.Domain.Entities;
using EconomiaFacilApp.Libraries.Domain.Interfaces.Services;

namespace EconomiaFacilApp.Libraries.Application.ServiceApp;

public class DespesaServiceApp(IMapper mapper, IDespesaService service) : IDespesaServiceApp
{
    private readonly IMapper mapper = mapper;
    private readonly IDespesaService service = service;

    public async Task<IEnumerable<ReadDespesaDto>> ObterDespesas()
    {
        var despesas = await service.GetModelsAsync();
        return mapper.Map<IEnumerable<ReadDespesaDto>>(despesas);
    }

    public ReadDespesaDto? ObterDespesaPeloId(int id)
    {
        var despesa = service.GetModelById(id);
        return despesa != null ? mapper.Map<ReadDespesaDto>(despesa) : null;
    }

    public async Task<bool> CadastrarDespesa(CreateDespesaDto despesaDto)
    {
        var despesa = mapper.Map<Despesa>(despesaDto);
        return await service.CreateModel(despesa);
    }

    public async Task<bool> AtualizarDespesa(UpdateDespesaDto despesaDto)
    {
        var despesa = mapper.Map<Despesa>(despesaDto);
        return await service.UpdateModel(despesa);
    }

    public async Task<bool> ExcluirDespesa(int id)
    {
        return await service.DeleteModel(id);
    }
}
