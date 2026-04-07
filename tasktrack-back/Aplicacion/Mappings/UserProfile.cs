using AutoMapper;
using Aplicacion.DTOs.User;
using Aplicacion.DTOs.UserPreferences;

namespace Aplicacion.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        // User → UserDto
        CreateMap<Dominio.Entities.User, UserDto>();

        CreateMap<UserDto, Dominio.Entities.User>();

        // UserPreferences → UserPreferenceDto
        CreateMap<Dominio.Entities.UserPreferences, UserPreferenceDto>();
    }
}
