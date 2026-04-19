using MediatR;
using AutoMapper;
using Aplicacion.DTOs.TagsDto;

public class CreateTagHandler
    : IRequestHandler<CreateTagCommand, TagsDto>
{
    private readonly ITagsRepository _repository;
    private readonly IMapper _mapper;

    public CreateTagHandler(ITagsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TagsDto> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        var tags = _mapper.Map<Dominio.Entities.Tags>(request);

        await _repository.AddAsync(tags);

        var tagDto = _mapper.Map<TagsDto>(tags);   

        return tagDto;
    }
}