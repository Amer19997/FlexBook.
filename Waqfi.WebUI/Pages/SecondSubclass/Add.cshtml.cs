using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Models.City;
using WebUI.Models.FirstSubclass;
using WebUI.Models.GovernanceClassification;
using WebUI.Models.SecondSubclass;

namespace WebUI.Pages.SecondSubclass
{
    public class AddModel : PageModel
    {
        private readonly ILookUpClient _lookup;

        public AddModel(ILookUpClient lookup)
        {
            _lookup = lookup;
        }

        [BindProperty]
        public SecondSubclassModel SecondSubclassModel { get; set; }

        public async Task<JsonResult> OnPostAsync()
        {
            var result = await _lookup.AddSecondSubclassclassCmsAsync(new AddSecondSubclassCommand()
            {
                NameAr = SecondSubclassModel.NameAr,
                NameEn = SecondSubclassModel.NameEn,
            });
            return new JsonResult(result);
        }
    }
}

