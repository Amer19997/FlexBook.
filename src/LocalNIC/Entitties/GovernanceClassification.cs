namespace Waqfi.LocalNIC.Entities;
public class GovernanceClassification
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public List<Society> Societies { get; set; }
}