using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.IntegrationServices;
using WebUI.Models.ProductUnit;
using WebUI.Models.Seasons;

namespace WebUI.Pages.Seasons
{
    [Authorize(Roles = SystemRoles.ViewSeasonList + " , " + SystemRoles.SuperAdmin)]

    public class AddModel : PageModel
    {
        private readonly ISeasonsClient _seasonsClient;

        [BindProperty]
        public SeasonAddModel Season { get; set; }
        public AddModel(ISeasonsClient seasonsClient)
        {
                _seasonsClient= seasonsClient;
        }
        public void OnGet()
        {
        }
        public async Task<JsonResult> OnPostAsync()
        {
            var result = await _seasonsClient.SeasonsPostAsync(new AddSeasonCommand()
            {
                NameAr = Season.NameAr,
                NameEn = Season.NameEn,
                Description= Season.Description,
                EndAt= Season.EndAt,
                StartAt = Season.StartAt
                
            });
            return new JsonResult(result);
        }
    }
}
