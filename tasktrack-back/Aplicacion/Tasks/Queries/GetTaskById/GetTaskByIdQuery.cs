using Aplicacion.DTOs.Tasks;
using MediatR;

// esta clase es el Query, es decir, la consulta que se va a realizar.
// recibe el id de la tarea y el id del usuario para poder obtener la tarea correspondiente.
// IRequest es una interfaz de MediatR que indica que esta clase es una solicitud que 
// espera retornar una respuesta de tipo TaskDto? (puede ser nula).

// record es una clase inmutable, es decir, no se pueden modificar sus propiedades 
// una vez creada la instancia
public record GetTaskByIdQuery(Guid TaskId, Guid UserId)
    : IRequest<TaskDto?>;