using AutoMapper;
using Dominio.Entities;
using Aplicacion.DTOs.Tasks;

namespace Aplicacion.Mappings;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<Dominio.Entities.Task, TaskDto>();
        // CreateMap<Task, TaskListItemDto>();

        CreateMap<CreateTaskCommand, Dominio.Entities.Task>()
            .ForMember(dest => dest.Id, opt => new Guid())
            .ForMember(dest => dest.IsArchived, opt => opt.MapFrom(src => false))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
            // .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            // .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            // .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
            // .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            // .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority));
            
    }
}
