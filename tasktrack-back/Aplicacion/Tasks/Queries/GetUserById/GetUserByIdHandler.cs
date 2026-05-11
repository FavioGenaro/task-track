using MediatR;
using AutoMapper;
using Aplicacion.DTOs.User;

public class GetUserByIdHandler
    : IRequestHandler<GetUserByIdQuery, UserDto?>
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    public GetUserByIdHandler(
        IUserRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(
            request.UserId
        );

        return user is null ? null : _mapper.Map<UserDto>(user);
    }
}
