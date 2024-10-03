using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Models.City;
using WebUI.Models.GovernanceClassification;

namespace WebUI.Pages.GovernanceClassification
{
    public class AddModel : PageModel
    {
        private readonly ILookUpClient _lookup;

        public AddModel(ILookUpClient lookup)
        {
            _lookup = lookup;
        }

        [BindProperty]
        public GovernanceClassificationModel ClassificationModel { get; set; }

        public async Task<JsonResult> OnPostAsync()
        {
            var result = await _lookup.AddGovernanceClassificationCmsAsync(new AddGovernanceClassificationCommand()
            {
                NameAr = ClassificationModel.NameAr,
                NameEn = ClassificationModel.NameEn,
            });
            return new JsonResult(result);
        }
    }
}

