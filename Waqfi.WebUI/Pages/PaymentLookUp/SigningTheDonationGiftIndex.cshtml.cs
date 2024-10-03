using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Helpers;

namespace WebUI.Pages.PaymentLookUp
{
    public class SigningTheDonationGiftIndexModel : PageModel
    {
        private readonly ILookUpClient _lookup;

        private readonly IAppSettingService _appSettingService;
        public GetSignaturePaymentQueryResultIReadOnlyListTResponse result;

        public SigningTheDonationGiftIndexModel(ILookUpClient lookUpClient, IAppSettingService appSettingService)
        {
            _lookup = lookUpClient;
            _appSettingService = appSettingService;
        }
        public async Task OnGet()
        {
            result = await _lookup.GetSignaturePaymentAsync();

        }
    }
}
