using Aplicacion.DTOs.Tasks;
using MediatR;
using AutoMapper;
using Dominio.Interfaces;

// IRequestHandler es una interfaz de MediatR que indica que esta clase es un manejador de solicitudes,
// en este caso, maneja la consulta GetTaskByIdQuery y retorna un TaskDto
public class GetTaskByIdHandler
    : IRequestHandler<GetTaskByIdQuery, TaskDto?>
{
    private readonly ITaskRepository _repository;
    private readonly IMapper _mapper;

    // GetTaskByIdHandler es el constructor de la clase, este recibe como parámetros 
    // las dependencias necesarias para manejar la consulta GetTaskByIdQuery
    public GetTaskByIdHandler(
        ITaskRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    // task es el método que maneja la consulta GetTaskByIdQuery, 
    // este recibe como parámetros la consulta y un token de cancelación, 
    // este método es el encargado de ejecutar la lógica para obtener
    public async Task<TaskDto?> Handle(
        GetTaskByIdQuery request,
        CancellationToken cancellationToken)
    {
        var task = await _repository.GetByIdAsync(
            request.TaskId,
            request.UserId
        );

        return task is null ? null : _mapper.Map<TaskDto>(task);
    }
}
