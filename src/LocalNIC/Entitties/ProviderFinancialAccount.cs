namespace Waqfi.LocalNIC.Entities;
public class ProviderFinancialAccount
{
    private ProviderFinancialAccount()
    {
        Id = Guid.NewGuid();
    }
    internal ProviderFinancialAccount(Guid providerId, Guid bankId, string swiftCode, string iBan, string accountNumber, string beneficiaryName, bool isDefault = false) : base()
    {
        SocietyId = providerId;
        SwiftCode = swiftCode;
        IBan = iBan;
        AccountNumber = accountNumber;
        BeneficiaryName = beneficiaryName;
        IsDefault = isDefault;
        BankId = bankId;
    }
    public Guid Id { get; set; }

    public Guid SocietyId { get; private set; }
    public Society? Society { get; set; }
    public string? SwiftCode { get; private set; }
    public string? IBan { get; private set; }
    public Guid BankId { get; private set; }
    public Bank? Bank { get; set; }
    public string? AccountNumber { get; private set; }
    public string? BeneficiaryName { get; private set; }
    public bool? IsDefault { get; private set; }

    public string? SecuredAccountNumber => AccountNumber.Substring(AccountNumber.Length - 4);

    internal void Update(Guid bankId, string swiftCode, string iBan, string accountNumber, string beneficiaryName)
    {
        SwiftCode = swiftCode;
        IBan = iBan;
        AccountNumber = accountNumber;
        BeneficiaryName = beneficiaryName;
    }

    internal void SetDefault(bool isDefault) => IsDefault = isDefault;

}
