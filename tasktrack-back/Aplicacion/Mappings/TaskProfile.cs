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
                            Id = tag.Id == Guid.Empty ? Guid.Empty : tag.Id,
                            Name = tag.Name ?? string.Empty,
                            Color = tag.Color ?? string.Empty
                        }).ToList()));


        CreateMap<CreateTaskCommand, Dominio.Entities.Task>()
            .ForMember(dest => dest.Id, opt => new Guid())
            .ForMember(dest => dest.IsArchived, opt => opt.MapFrom(src => false))
            // .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.TaskDto.Title))
            // .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.TaskDto.Description))
            // .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.TaskDto.DueDate))
            // .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.TaskDto.Status))
            // .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.TaskDto.Priority))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.Tags, opt => opt.MapFrom(src =>
                        src.TagIds.Select(tt => new TagsTask{
                            TagId = tt
                        }).ToList()));
            
    }
}
