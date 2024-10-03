namespace Waqfi.LocalNIC.Entities;
public class Bank
{
    public Guid Id  { get; set; }
    public DescriptionLocalized? Name { get; private set; }
    public List<ProviderFinancialAccount> ProviderFinancialAccounts { get; set; }
}
