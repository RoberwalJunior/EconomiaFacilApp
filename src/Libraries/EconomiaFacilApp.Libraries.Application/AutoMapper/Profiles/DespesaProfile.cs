using AutoMapper;
using EconomiaFacilApp.Libraries.Domain.Entities;
using EconomiaFacilApp.Libraries.Application.AutoMapper.Dtos.Despesas;

namespace EconomiaFacilApp.Libraries.Application.AutoMapper.Profiles;

public class DespesaProfile : Profile
{
    public DespesaProfile()
    {
        CreateMap<CreateDespesaDto, Despesa>();
        CreateMap<Despesa, ReadDespesaDto>()
            .ForMember(despesaDto => despesaDto.FormaPagamento,
                opt => opt.MapFrom(despesa => despesa.FormaPagamento.ToString()));
        CreateMap<UpdateDespesaDto, Despesa>();
    }
}
