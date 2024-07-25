using AutoMapper;
using EconomiaFacilApp.Libraries.Domain.Entities;
using EconomiaFacilApp.Libraries.Application.AutoMapper.Dtos.Categorias;

namespace EconomiaFacilApp.Libraries.Application.AutoMapper.Profiles;

public class CategoriaProfile : Profile
{
    public CategoriaProfile()
    {
        CreateMap<CreateCategoriaDto, Categoria>();
        CreateMap<Categoria, ReadCategoriaDto>()
            .ForMember(categoriaDto => categoriaDto.Tipo,
                opt => opt.MapFrom(categoria => categoria.Tipo.ToString()));
        CreateMap<UpdateCategoriaDto, Categoria>();
    }
}
