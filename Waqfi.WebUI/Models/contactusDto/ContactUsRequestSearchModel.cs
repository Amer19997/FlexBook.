using WebUI.Client;

namespace WebUI.Models.contactusDto;

public class ContactUsRequestSearchModel
{
    public int? RequestNumber { get; set; }
    public ContactUsType? Type { get; set; }
    public ContactUsStatues? Status { get; set; }

    public string? Contains { get; set; }
}
