using Aplicacion.DTOs.Tasks;
using MediatR;
using AutoMapper;
using Dominio.Interfaces;

// IRequestHandler es una interfaz de MediatR que indica que esta clase es un manejador de solicitudes,
// en este caso, maneja la consulta GetTaskByIdQuery y retorna un TaskDto
public class GetTasksByUserHandler
    : IRequestHandler<GetTasksByUserQuery, IReadOnlyList<TaskDto>>
{
    private readonly ITaskRepository _repository;
    private readonly IMapper _mapper;

    public GetTasksByUserHandler(
        ITaskRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<TaskDto>> Handle(
        GetTasksByUserQuery request,
        CancellationToken cancellationToken)
    {
        var tasks = await _repository.GetByUserAsync(request.UserId);
        
        return _mapper.Map<IReadOnlyList<TaskDto>>(tasks);
    }
}
