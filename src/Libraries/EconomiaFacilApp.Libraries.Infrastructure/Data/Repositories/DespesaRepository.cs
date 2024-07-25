﻿using EconomiaFacilApp.Libraries.Domain.Entities;
using EconomiaFacilApp.Libraries.Domain.Interfaces.Repositories;
using EconomiaFacilApp.Libraries.Infrastructure.Data.Context;
using EconomiaFacilApp.Libraries.Infrastructure.Data.Repositories.Base;

namespace EconomiaFacilApp.Libraries.Infrastructure.Data.Repositories;

public class DespesaRepository(AppDbContext context)
    : BaseRepository<Despesa>(context), IDespesaRepository
{
}
