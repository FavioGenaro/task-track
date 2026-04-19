using AutoMapper;
using Dominio.Entities;
using Aplicacion.DTOs;

namespace Aplicacion.Mappings;

public class TagProfile : Profile
{
    public TagProfile()
    {

        CreateMap<CreateTagCommand, Tags>()
            .ForMember(dest => dest.Id, opt => new Guid());
        
        CreateMap<Tags, TagsDto>();
    }
}
