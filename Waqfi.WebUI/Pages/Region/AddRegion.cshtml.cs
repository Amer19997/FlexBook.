using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Models.Region;

namespace WebUI.Pages.Region
{
    public class AddRegionModel : PageModel
    {
        private readonly ILookUpClient _lookup;

        public AddRegionModel(ILookUpClient lookup)
        {
            _lookup = lookup;
        }

        [BindProperty]
        public RegionModel RegionModel { get; set; }

        public async Task<JsonResult> OnPostAsync()
        {
            var result = await _lookup.AddRegionCmsAsync(new AddRegionCommand()
            {
                NameAr = RegionModel.NameAr,
                NameEn = RegionModel.NameEn,
                 Postalcode= RegionModel.PostalCode
            });
            return new JsonResult(result);
        }
    }
}
