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
    }
}
