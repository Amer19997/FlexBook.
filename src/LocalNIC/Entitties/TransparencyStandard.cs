namespace Waqfi.LocalNIC.Entities;

public class TransparencyStandard
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public List<Society>? Societies { get; set; }
}