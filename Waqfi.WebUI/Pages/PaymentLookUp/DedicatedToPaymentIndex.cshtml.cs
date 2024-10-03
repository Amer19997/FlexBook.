using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Helpers;

namespace WebUI.Pages.PaymentLookUp
{
    public class DedicatedToPaymentIndexModel : PageModel
    {
        private readonly ILookUpClient _lookup;

        private readonly IAppSettingService _appSettingService;
        public GetDedicatedToPaymentQueryResultIReadOnlyListTResponse result;

        public DedicatedToPaymentIndexModel(ILookUpClient lookUpClient, IAppSettingService appSettingService)
        {
            _lookup = lookUpClient;
            _appSettingService = appSettingService;
        }
        public async Task OnGet()
        {
            result = await _lookup.GetDedicatedToPaymentAsync();

        }
    }
}
