using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Models.City;
using WebUI.Models.FirstSubclass;
using WebUI.Models.GovernanceClassification;

namespace WebUI.Pages.FirstSubclass
{
    public class AddModel : PageModel
    {
        private readonly ILookUpClient _lookup;

        public AddModel(ILookUpClient lookup)
        {
            _lookup = lookup;
        }

        [BindProperty]
        public FirstSubclassModel FirstSubclassModel { get; set; }

        public async Task<JsonResult> OnPostAsync()
        {
            var result = await _lookup.AddFirstSubclassCmsAsync(new AddFirstSubclassCommand()
            {
                NameAr = FirstSubclassModel.NameAr,
                NameEn = FirstSubclassModel.NameEn,
            });
            return new JsonResult(result);
        }
    }
}

