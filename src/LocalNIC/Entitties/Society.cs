namespace Waqfi.LocalNIC.Entities;
public class Society
{
    protected Society() { Id = Guid.NewGuid(); }

    protected Society(string identityNumber, string commercialRegistrationNumber, DescriptionLocalized name, DateTimeOffset? licenseStartDate, DateTimeOffset licenseEndDate, TargetGenders targetGender, RequestStatus requestStatus) : base()
    {


        RegistrationNumber = identityNumber;
        CommercialRegistrationNumber = commercialRegistrationNumber;
        Name = name;
        LicenseStartDate = licenseStartDate;
        LicenseEndDate = licenseEndDate;
        TargetGender = targetGender;
        IsActive = true;
        RequestStatus = requestStatus;

    }

    public static Society Init(string identityNumber, string commercialRegistrationNumber, DescriptionLocalized name, DateTimeOffset? licenseStartDate, DateTimeOffset licenseEndDate, TargetGenders targetGender, RequestStatus requestStatus)
    {
        return new Society(identityNumber, commercialRegistrationNumber, name, licenseStartDate, licenseEndDate, targetGender, requestStatus);
    }
    public bool GovernanceDegree { get; set; }
    public Guid? GovernanceClassificationId { get; set; }

    public string? GovernanceClassification { get; set; }
    public Guid? QualitativeClassificationId { get; set; }

    public QualitativeClassification? QualitativeClassification { get; set; }
    public Guid? TransparencyStandardId { get; set; }
    public TransparencyStandard? TransparencyStandard { get; set; }
    public Guid? FirstSubclassId { get; set; }
    public FirstSubclass? FirstSubclass { get; set; }
    public Guid? SecondSubclassId { get; set; }
    public SecondSubclass? SecondSubclass { get; set; }
    public SocietyStatusEnum? SocietyStatus { get; set; }
    public Guid Id { get; set; }
    public string RegistrationNumber { get; private set; }
    public string? CommercialRegistrationNumber { get; private set; }
    public DescriptionLocalized? Name { get; private set; }
    public DateTimeOffset? LicenseStartDate { get; private set; }
    public DateTimeOffset? LicenseEndDate { get; private set; }
    public TargetGenders? TargetGender { get; private set; }
    public bool? IsActive { get; private set; } = false;
    public RequestStatus? RequestStatus { get; private set; }

    public ProviderContactDetails? Contacts { get; private set; }
    public ProviderAddress? Address { get; private set; }
    public SocialAccount? SocialAccount { get; private set; }

    public List<ProviderFile> ProviderFiles { get; set; }
    public List<ProviderFinancialAccount> ProviderFinancialAccounts { get; set; }
    public BoardChairman? BoardChairman { get; private set; }
    public List<BoardMember> BoardMembers { get; set; }
    public CEO? CEO { get; private set; }

    public List<Delegate> Delegates { get; set; }

   }
