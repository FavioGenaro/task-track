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
    private readonly IMapper _mapper;

    public ChangeStatusByIdHandler(
        ITaskRepository repository,
        IMapper mapper,
        ITaskHistoryRepository historyRepository)
    {
        _repository = repository;
        _mapper = mapper;
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

        // var task = await _repository.ChangeStatusByIdAsync(
        //     request.TaskId,
        //     request.UserId,
        //     request.NewStatus
        // );

        var history = new TaskHistory
        {
            // Id = Guid.NewGuid(),
            TaskId = request.TaskId,
            PreviousStatus = previousStatus,
            NewStatus = request.NewStatus,
            ChangedAt = DateTime.UtcNow
        };

        await _historyRepository.AddAsync(history);

        return true;
    }
}
