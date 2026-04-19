using AutoMapper;
using Dominio.Entities;
using Aplicacion.DTOs.Tasks;
using Aplicacion.DTOs;

namespace Aplicacion.Mappings;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<Dominio.Entities.Task, TaskDto>()
            .ForMember(dest => dest.Tags,
                    opt => opt.MapFrom(src =>
                        src.Tags
                        .Select(tt => tt.Tag)
                        .Select(tag => new TagsDto
                        {
                            Name = tag.Name ?? string.Empty,
                            Color = tag.Color ?? string.Empty
                        }).ToList()));


        CreateMap<CreateTaskCommand, Dominio.Entities.Task>()
            .ForMember(dest => dest.Id, opt => new Guid())
            .ForMember(dest => dest.IsArchived, opt => opt.MapFrom(src => false))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.Tags, opt => opt.MapFrom(src =>
                        src.TagIds.Select(tt => new TagsTask{
                            TagId = tt
                        }).ToList()));
            // .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            // .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            // .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
            // .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            // .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority));
            
    }
}
