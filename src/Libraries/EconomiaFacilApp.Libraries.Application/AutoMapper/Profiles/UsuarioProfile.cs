using AutoMapper;
using EconomiaFacilApp.Libraries.Domain.Entities.Identity;
using EconomiaFacilApp.Libraries.Application.AutoMapper.Dtos.Usuarios;

namespace EconomiaFacilApp.Libraries.Application.AutoMapper.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<CreateUsuarioDto, UsuarioComAcesso>();
    }
}
