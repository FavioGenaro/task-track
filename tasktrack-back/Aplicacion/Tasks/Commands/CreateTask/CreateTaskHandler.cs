using MediatR;
using AutoMapper;
using Aplicacion.DTOs.Tasks;
using Dominio.Interfaces;

public class CreateTaskHandler
    : IRequestHandler<CreateTaskCommand, Guid>
{
    private readonly ITaskRepository _repository;
    private readonly ITagsRepository _tagsRepository;
    private readonly IMapper _mapper;

    public CreateTaskHandler(ITaskRepository repository, ITagsRepository tagsRepository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _tagsRepository = tagsRepository;
    }

    public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = _mapper.Map<Dominio.Entities.Task>(request);

        await _repository.AddAsync(task);
        
        return task.Id;
    }
}