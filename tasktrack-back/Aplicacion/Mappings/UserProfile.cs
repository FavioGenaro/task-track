using AutoMapper;
using Aplicacion.DTOs.User;

namespace Aplicacion.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<Dominio.Entities.User, UserDto>();
        CreateMap<UserDto, Dominio.Entities.User>();
    }
}
