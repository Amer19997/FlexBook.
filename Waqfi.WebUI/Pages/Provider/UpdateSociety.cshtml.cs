using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Waqfi.Application.Common.Interfaces;
using WebUI.Client;
using WebUI.Models.Provider;

namespace WebUI.Pages.Provider
{
    public class UpdateSocietyModel : PageModel
    {
        private readonly IResourceService _resourceHandler;
        public ISocietyClient _societyClient { get; set; }
        public IProviderClient _ProviderClient { get; set; }
        public ILookUpClient _LookUpClient { get; set; }
        public IMapper _mapper;

        [BindProperty]
        public SocietyUpdate AssociationDetails { get; set; }
        public SelectList Bank { get; set; }
        public SelectList City { get; set; }
        public SelectList Region { get; set; }
        public SelectList FirstSubclass { get; set; }
        public SelectList SecondSubclass { get; set; }
        public SelectList Governance { get; set; }
        public SelectList QualitativeClass { get; set; }
        public SelectList TransparencyStandard { get; set; }

        public List<string> Error { get; set; }
        public UpdateSocietyModel(ISocietyClient societyClient, 
                                  IProviderClient providerClient,
                                  ILookUpClient lookUpClient,
                                  IMapper mapper,
                                  IResourceService resourceHandler)
        {
            _societyClient = societyClient;
            _ProviderClient = providerClient;
            _LookUpClient = lookUpClient;
            _mapper = mapper;
            _resourceHandler = resourceHandler;
            Error = new List<string>();
        }
        public async Task<IActionResult> OnGet(string societyId)
        {
            var result = await _societyClient.GetSocityDetailsForCMSEditionAsync(Guid.Parse(societyId));
            Bank = new SelectList((await _LookUpClient.GetBankListAsync()).Result.ToList(), "Id", "NameAr");
            City = new SelectList((await _LookUpClient.GetCityCmsGetAsync(1000, 1)).Result.Items, "Id", "NameAr");
            Region = new SelectList((await _LookUpClient.GetRegionListAsync()).Result.ToList(), "Id", "NameAr");
            FirstSubclass = new SelectList((await _LookUpClient.GetFirstSubclassCmsGetAsync(1000,1)).Result.Items, "Id", "NameAr"); 
            SecondSubclass =  new SelectList((await _LookUpClient.GetSecondSubclassclassCmsAsync(1000,1)).Result.Items, "Id", "NameAr"); 
            Governance = new SelectList((await _LookUpClient.GetGovernanceCmsAsync(1000,1)).Result.Items, "Id", "NameAr");
            QualitativeClass = new SelectList((await _LookUpClient.GetQualitativeClassificationListAsync(1,1000)).Result.Items, "Id", "NameAr");
            List<int> numberList = new List<int>();
            for (int i = 1; i <= 100; i++)
            {
                numberList.Add(i);
            }

            // Use the list to initialize a SelectList
            TransparencyStandard = new SelectList(numberList);

            new SelectList((await _LookUpClient.GetQualitativeClassificationListAsync(1000, 1)).Result.Items, "Id", "NameAr");

            if (!result.Success)
            {
                Error = result.Errors.ToList();
                return RedirectToPage("/Provider/ProvidersRequests", new { error = Error });
            }
            var model = result.Result;
            AssociationDetails = _mapper.Map<SocietyUpdate>(model);
            return Page();
        }
        public async Task<JsonResult> OnPost()
        {
            if(AssociationDetails.BankDto==null)
                return new JsonResult(new TResponse() { Errors = new List<string>() { "يجب رفع حساب بنكى واحد على الاقل" } });
            var resultCheck = CheckFinacial(AssociationDetails);
            if (resultCheck.Count > 0)
            {
                Error.AddRange(resultCheck);
                return new JsonResult(new TResponse() { Errors = resultCheck });

            }

            var command = _mapper.Map<UpdateSocityForCMSEditionCommand>(AssociationDetails);
            var result = await _societyClient.UpdateSocityForCMSEditionAsync(command);

            if (result.Success)
                return new JsonResult(new TResponse() { Success = true });
            else
                return new JsonResult(new TResponse() { Errors = result.Errors.ToList() });

        }
        private List<string> CheckFinacial(SocietyUpdate associationDetails)
        {
            var resultMessage = new List<string>();
            var Accountflag = true;
            var IBANflag = true;
            foreach (var item in associationDetails.BankDto.BankInfoList)
            {
                if (!Accountflag && !IBANflag)
                    break;

                if (Accountflag && associationDetails.BankDto.BankInfoList.Any(m => m.BankAccountNumber == item.BankAccountNumber && m != item && m.BankAccountNumber != "-"))
                {
                    resultMessage.Add(_resourceHandler.GetError("AccountNumberExist"));
                    Accountflag = false;
                }
                if (IBANflag && associationDetails.BankDto.BankInfoList.Any(m => m.IbanAccountNumber == item.IbanAccountNumber && m != item))
                {
                    resultMessage.Add(_resourceHandler.GetError("IBANExist"));
                    IBANflag = false;
                }
            }

            return resultMessage;
        }
    }
}
