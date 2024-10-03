using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Waqfi.Application.Common.Interfaces;
using WebUI.Client;
using WebUI.Models.Provider;

namespace WebUI.Pages.Provider
{
    public class UpdateAssociationModel : PageModel
    {
        private readonly IResourceService _resourceHandler;
        public IAssociationsClient _associationsClient { get; set; }
        public IProviderClient _ProviderClient { get; set; }
        public ILookUpClient _LookUpClient { get; set; }
        public IMapper _mapper;

        [BindProperty]
        public AssociationUpdate AssociationDetails { get; set; }
        public SelectList Bank { get; set; }
        public SelectList City { get; set; }
        public SelectList Region { get; set; }

        public List<string> Error { get; set; }
        public UpdateAssociationModel(IAssociationsClient associationsClient, IProviderClient providerClient, ILookUpClient lookUpClient, IMapper mapper, IResourceService resourceHandler)
        {
            _associationsClient = associationsClient;
            _ProviderClient = providerClient;
            _LookUpClient = lookUpClient;
            _mapper = mapper;
            _resourceHandler = resourceHandler;
            Error = new List<string>();
        }
        public async Task<IActionResult> OnGet(string associationId)
        {
            var result = await _associationsClient.GetAssociationDetailsForCMSEditionAsync(Guid.Parse(associationId));
            Bank = new SelectList((await _LookUpClient.GetBankListAsync()).Result.ToList(), "Id", "NameAr");
            City = new SelectList((await _LookUpClient.GetCityCmsGetAsync(1000, 1)).Result.Items, "Id", "NameAr");
            Region = new SelectList((await _LookUpClient.GetRegionListAsync()).Result.ToList(), "Id", "NameAr");

            if (!result.Success)
            {
                Error = result.Errors.ToList();
                return RedirectToPage("/Provider/ProvidersRequests", new { error = Error });
            }
            var model = result.Result;
            AssociationDetails = _mapper.Map<AssociationUpdate>(model);
            return Page();
        }
        public async Task<JsonResult> OnPost()
        {
            if (AssociationDetails.BankInfoList == null)
                return new JsonResult(new TResponse() { Errors = new List<string>() { "??? ??? ???? ???? ???? ??? ?????" } });

            var resultCheck =  CheckFinacial(AssociationDetails);
            if (resultCheck.Count > 0)
            {
                Error.AddRange(resultCheck);
                return new JsonResult(new TResponse() { Errors = resultCheck });

            }

            var command = _mapper.Map<UpdateAssociationForCMSEditionCommand>(AssociationDetails);
            var result=await _associationsClient.UpdateAssociationForCMSEditionAsync(command);

            if (result.Success)
                return new JsonResult(new TResponse() { Success = true });
            else
                return new JsonResult(new TResponse() { Errors = result.Errors.ToList() });
            
        }
        private List<string> CheckFinacial(AssociationUpdate associationDetails)
        {
            var resultMessage = new List<string>();
            var Accountflag = true;
            var IBANflag = true;
            foreach (var item in associationDetails.BankInfoList.BankInfoList)
            {
                if (!Accountflag && !IBANflag)
                    break;

                if (Accountflag && associationDetails.BankInfoList.BankInfoList.Any(m => m.BankAccountNumber == item.BankAccountNumber && m != item && m.BankAccountNumber != "-"))
                {
                    resultMessage.Add(_resourceHandler.GetError("AccountNumberExist"));
                    Accountflag = false;
                }
                if (IBANflag && associationDetails.BankInfoList.BankInfoList.Any(m => m.IbanAccountNumber == item.IbanAccountNumber && m != item))
                {
                    resultMessage.Add(_resourceHandler.GetError("IBANExist"));
                    IBANflag = false;
                }
            }

            return resultMessage;
        }

    }
}
