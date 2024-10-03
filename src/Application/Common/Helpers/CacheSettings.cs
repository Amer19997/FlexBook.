namespace FlexBook.Application.Common.Helpers;
public class CacheSettings
{
    public double ExpirationTimeInMinutes { get; set; }
    public int Remaining { get; set; }
    public int ObjectExpirationAfterMinutes { get; set; }
    public int OTPExpirationAfterMinutes { get; set; }
    public int LoginOTPBlockTimeInMinutes { get; set; }
    public int SocietyStepZeroCounter { get; set; }
    public int UpdateMobileDonatorCounter { get; set; }
    public int SocietyStepZeroBlocked { get; set; }
    public int SocietyStepZeroExpirationTimeOTP { get; set; }

    public int SocietyRegistrationExpirationTimeInMinutes { get; set; }
    public int AssociationRegistrationExpirationTimeInMinutes { get; set; }
}
