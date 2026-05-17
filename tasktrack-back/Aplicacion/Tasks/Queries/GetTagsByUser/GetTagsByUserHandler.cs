using Aplicacion.DTOs.Tasks;
using MediatR;
using AutoMapper;
using Dominio.Interfaces;
using Aplicacion.DTOs;

// IRequestHandler es una interfaz de MediatR que indica que esta clase es un manejador de solicitudes,
// en este caso, maneja la consulta GetTaskByIdQuery y retorna un TaskDto
public class GetTagsByUserHandler
    : IRequestHandler<GetTagsByUserQuery, IReadOnlyList<TagsDto>>
{
    private readonly ITagsRepository _repository;
    private readonly IMapper _mapper;

    public GetTagsByUserHandler(
        ITagsRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<TagsDto>> Handle(GetTagsByUserQuery request, CancellationToken cancellationToken)
    {
        var tags = await _repository.GetByUserAsync(request.UserId);
        
        return _mapper.Map<IReadOnlyList<TagsDto>>(tags);
    }
}
