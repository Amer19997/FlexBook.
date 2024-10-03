using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.IntegrationServices;

namespace WebUI.Pages.Banner
{
    [Authorize(Roles = SystemRoles.Banner + " , " + SystemRoles.SuperAdmin)]
    public class BannerDetailsModel : PageModel
    {
        private readonly IBannerClient _BannerClient;

        public string Error { get; set; }

        [BindProperty]
        public GetBannerDetailsQueryResult BannerDetailsResult { get; set; }
        public BannerDetailsModel(IBannerClient BannerClient)
        {
            this._BannerClient = BannerClient;
        }
        public async Task<IActionResult> OnGet(Guid BannerId)
        {
            var result = await _BannerClient.GetBannerDetailsCMSAsync(BannerId);

            if (!result.Success)
            {
                Error = result.Errors.FirstOrDefault();
                return RedirectToPage("/Banner/Index", new { error = Error });
            }

            BannerDetailsResult=result.Result;

            return Page();
        }

        [HttpGet]
        public async Task<IActionResult> OnGetDownloadFile(string fileId, string BannerId)
        {
            var file = await _BannerClient.GetBannerFileByIdCMSAsync(Guid.Parse(BannerId), Guid.Parse(fileId));
            return new OkObjectResult(file);

        }

       
    }
}
