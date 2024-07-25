using EconomiaFacilApp.Libraries.Domain.Entities;
using EconomiaFacilApp.Libraries.Domain.Services.Base;
using EconomiaFacilApp.Libraries.Domain.Interfaces.Services;
using EconomiaFacilApp.Libraries.Domain.Interfaces.Repositories;

namespace EconomiaFacilApp.Libraries.Domain.Services;

public class DespesaService(IDespesaRepository repository) 
    : BaseService<Despesa>(repository), IDespesaService
{
}
