using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Models.Lookups;

namespace WebUI.Pages.ReportType
{
    public class AddModel : PageModel
    {
        private readonly ILookUpClient _lookupClient;

        [BindProperty]
        public ReportTypeModel ReportTypeModel { get; set; }
        public AddModel(ILookUpClient lookupClient)
        {
            _lookupClient = lookupClient;
        }
        public async Task<JsonResult> OnPostAsync()
        {
            var result = await _lookupClient.AddReportTypeAsync(new AddReportTypeCommand()
            {
                NameAr = ReportTypeModel.NameAr,
                NameEn = ReportTypeModel.NameEn
            });
            return new JsonResult(result);
        }
    }
}
