using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.IntegrationServices;
using WebUI.Models.Lookups;
using WebUI.Models.ProductUnit;

namespace WebUI.Pages.Bank
{
    [Authorize(Roles = SystemRoles.ViewProductUnitList + " , " + SystemRoles.SuperAdmin)]
    public class EditModel : PageModel
    {
        private readonly ILookUpClient  _lookUpClient;
        private readonly IMapper _mapper;

        [BindProperty]
        public BankModel BankModel { get; set; }
        public EditModel(ILookUpClient lookUpClient , IMapper mapper)
        {
            _lookUpClient = lookUpClient;
            _mapper = mapper;
        }
        public async Task OnGetAsync(Guid id)
        {
            var result = await _lookUpClient.GetBankAsync(id);
            if (result.Success)
                BankModel = _mapper.Map<BankModel>(result.Result);
        }
        public async Task<JsonResult> OnPostAsync()
        {
            var result = await _lookUpClient.EditBankAsync(new EditBankCommand()
            {
                Id= BankModel.Id,
                NameAr = BankModel.NameAr,
                NameEn = BankModel.NameEn,
                  SwiftCode= BankModel.swiftCode
            });
            return new JsonResult(result);
        }
        
    }
}
