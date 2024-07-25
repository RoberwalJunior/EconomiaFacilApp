using EconomiaFacilApp.Libraries.Application.AutoMapper.Dtos.Despesas;

namespace EconomiaFacilApp.Libraries.Application.Interfaces;

public interface IDespesaServiceApp
{
    public Task<IEnumerable<ReadDespesaDto>> ObterDespesas();
    public ReadDespesaDto? ObterDespesaPeloId(int id);
    public Task<bool> CadastrarDespesa(CreateDespesaDto despesaDto);
    public Task<bool> AtualizarDespesa(int id, UpdateDespesaDto despesaDto);
    public Task<bool> ExcluirDespesa(int id);
}
