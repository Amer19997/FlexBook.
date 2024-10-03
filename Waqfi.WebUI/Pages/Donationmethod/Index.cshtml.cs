using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Helpers;

namespace WebUI.Pages.Donationmethod
{
    public class IndexModel : PageModel
    {
        private readonly ILookUpClient _lookup;
        private readonly IAppSettingService _appSettingService;
        public DonationmethodCmsDtoPaginatedList lookupList { get; set; }
        public IndexModel(ILookUpClient lookUpClient, IAppSettingService appSettingService)
        {
            _lookup = lookUpClient;
            _appSettingService = appSettingService;
        }
        public async Task OnGetAsync(int p)
        {
            var result = (await _lookup.GetDonationmethodCmsAsync(_appSettingService.Pager_PageSize, p == 0 ? 1 : p));
            if (result.Success)
                lookupList = result.Result;
        }
      

    }
}
