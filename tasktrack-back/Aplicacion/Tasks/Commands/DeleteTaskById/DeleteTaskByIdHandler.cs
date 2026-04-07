using Aplicacion.DTOs.Tasks;
using MediatR;
using AutoMapper;
using Dominio.Interfaces;

public class DeleteTaskByIdHandler
    : IRequestHandler<DeleteTaskByIdCommand, bool>
{
    private readonly ITaskRepository _repository;

    public DeleteTaskByIdHandler(
        ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        DeleteTaskByIdCommand request,
        CancellationToken cancellationToken)
    {
        var task = await _repository.DeleteByIdAsync(
            request.TaskId,
            request.UserId
        );

        return task is false ? false : true;
    }
}
