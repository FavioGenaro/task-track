using Aplicacion.DTOs.Tasks;
using MediatR;
using AutoMapper;
using Dominio.Interfaces;

public class GetTaskByIdHandler
    : IRequestHandler<GetTaskByIdQuery, TaskDto?>
{
    private readonly ITaskRepository _repository;
    private readonly IMapper _mapper;

    public GetTaskByIdHandler(
        ITaskRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TaskDto?> Handle(
        GetTaskByIdQuery request,
        CancellationToken cancellationToken)
    {
        var task = await _repository.GetByIdAsync(
            request.TaskId,
            request.UserId);

        return task is null ? null : _mapper.Map<TaskDto>(task);
    }
}
