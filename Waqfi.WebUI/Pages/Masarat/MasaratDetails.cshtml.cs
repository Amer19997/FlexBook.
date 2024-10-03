using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.IntegrationServices;

namespace WebUI.Pages.Masarat
{
    [Authorize(Roles = SystemRoles.ViewMasaratList + " , " + SystemRoles.SuperAdmin)]
    public class MasaratDetailsModel : PageModel
    {
        public readonly ILookUpClient _lookUpClient;
        public readonly IAssociationsClient _associationsClient;

        public GetMasaratItemQueryResult MasaratDetails { get; set; }
        public MasaratDetailsModel(ILookUpClient lookUpClient, IAssociationsClient associationsClient)
        {
            this._lookUpClient = lookUpClient;
            _associationsClient = associationsClient;
        }
        public async Task<IActionResult> OnGet(Guid MasaratId)
        {
            var result = (await _lookUpClient.GetMasaratDetailsAsync(MasaratId));

            if (!result.Success)
            {
                return RedirectToPage("/Masarat/index");
            }
           
            MasaratDetails = result.Result;

            return Page();
        }

        [HttpGet]
        public async Task<IActionResult> OnGetDownloadFile(string fileId, string masarId)
        {
            

            var file = await _lookUpClient.FileMasarArrayByIdAsync( Guid.Parse(masarId), Guid.Parse(fileId));

            return new OkObjectResult(file);

        }
    }
}
