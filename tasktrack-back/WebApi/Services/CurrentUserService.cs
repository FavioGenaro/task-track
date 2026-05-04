using System.Security.Claims;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid? UserId
    {
        get
        {
            var userId = _httpContextAccessor.HttpContext!
                .User
                .Claims.FirstOrDefault(x => x.Type == "sub")?.Value;

            if (userId is null)
            {
                return null;
            }

            return Guid.Parse(userId);
        }
    }
}