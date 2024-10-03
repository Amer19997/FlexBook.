namespace FlexBook.Application.Common.Helpers;
public class OTPSettings
{
    public string OTPValue { get; set; }
   // public int Remaining { get; set; }
    public DateTime FromTime { get; set; }
    public int ObjectExpirationAfterMinutes { get; set; }
    public int OTPExpirationAfterMinutes { get; set; }
   // public double BlockTimeInMinutes { get; set; }
    public int SendOTPCount { get; set; }
    public int VerifayCounter { get; set; }


}
