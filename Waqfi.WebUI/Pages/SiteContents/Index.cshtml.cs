using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Helpers;
using WebUI.IntegrationServices;

namespace WebUI.Pages.SiteContents
{
    [Authorize(Roles = SystemRoles.SiteContent + " , " + SystemRoles.SuperAdmin)]
    public class IndexModel : PageModel
    {
        private readonly ISiteContentClient _siteContentClient;
       
        [BindProperty]
        public GetAllAboutUsQueryResult AboutUs { get; set; }
        public IndexModel(ISiteContentClient siteContentClient)
        {
            _siteContentClient=siteContentClient;
             AboutUs = new GetAllAboutUsQueryResult();
        }
        public async Task OnGet()
        {
            var result = (await _siteContentClient.GetAllSiteContentAsync());
            if (result.Success)
                AboutUs = result.Result;
           
        }
    }
}
