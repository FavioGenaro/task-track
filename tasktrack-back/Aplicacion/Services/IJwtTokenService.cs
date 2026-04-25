using Dominio.Entities;

public interface IJwtTokenService
{
    string GenerateToken(User user);
}