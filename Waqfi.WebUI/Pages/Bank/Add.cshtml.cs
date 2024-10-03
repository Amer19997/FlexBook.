using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.IntegrationServices;
using WebUI.Models.Lookups;

namespace WebUI.Pages.Bank
{
    [Authorize(Roles = SystemRoles.SuperAdmin)]
    public class AddModel : PageModel
    {
        private readonly ILookUpClient _lookUpClient;

        [BindProperty]
        public BankModel BankModel { get; set; }
        public AddModel(ILookUpClient lookupClient)
        {
            _lookUpClient = lookupClient;
        }
        public async Task<JsonResult> OnPostAsync()
        {
            var result = await _lookUpClient.AddBankAsync(new AddBankCommand()

            {
                NameAr= BankModel.NameAr,
                NameEn= BankModel.NameEn,
                SwiftCode= BankModel.swiftCode
            });
            return new JsonResult(result);
        }
    }
}
