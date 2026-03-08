namespace Dominio.Entities;

public class Tags
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Color { get; set; }
}
