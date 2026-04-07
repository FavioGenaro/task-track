using Aplicacion.DTOs.Tasks;
using MediatR;
using AutoMapper;
using Dominio.Interfaces;
using Dominio.Entities;

public class ChangeStatusByIdHandler
    : IRequestHandler<ChangeStatusByIdCommand, bool>
{
    private readonly ITaskRepository _repository;
    private readonly ITaskHistoryRepository _historyRepository;

    public ChangeStatusByIdHandler(
        ITaskRepository repository,
        ITaskHistoryRepository historyRepository)
    {
        _repository = repository;
        _historyRepository = historyRepository;
    }

    public async Task<bool> Handle(
        ChangeStatusByIdCommand request,
        CancellationToken cancellationToken)
    {

        var task = await _repository.GetByIdAsync(request.TaskId, request.UserId);

        if (task == null)
            return false;

        var previousStatus = task.Status;

        task.Status = request.NewStatus;
        task.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateAsync(task);

        var history = new TaskHistory
        {
            TaskId = request.TaskId,
            PreviousStatus = previousStatus,
            NewStatus = request.NewStatus,
            ChangedAt = DateTime.UtcNow
        };

        await _historyRepository.AddAsync(history);

        return true;
    }
}
