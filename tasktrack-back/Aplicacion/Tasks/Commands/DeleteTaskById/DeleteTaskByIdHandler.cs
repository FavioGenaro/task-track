using Aplicacion.DTOs.Tasks;
using MediatR;
using AutoMapper;
using Dominio.Interfaces;

public class DeleteTaskByIdHandler
    : IRequestHandler<DeleteTaskByIdCommand, int?>
{
    private readonly ITaskRepository _repository;
    private readonly IMapper _mapper;

    public DeleteTaskByIdHandler(
        ITaskRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<int?> Handle(
        DeleteTaskByIdCommand request,
        CancellationToken cancellationToken)
    {
        var task = await _repository.DeleteByIdAsync(
            request.TaskId,
            request.UserId
        );

        return task is null ? null : 1;
    }
}
