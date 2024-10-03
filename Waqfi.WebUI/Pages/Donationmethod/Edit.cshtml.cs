using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Models.City;
using WebUI.Models.Donationmethod;
using WebUI.Models.FirstSubclass;
using WebUI.Models.Gender;
using WebUI.Models.GovernanceClassification;

namespace WebUI.Pages.Donationmethod
{
    public class EditModel : PageModel
    {
        public ILookUpClient lookUpClient { get; set; }
        private readonly IMapper _mapper;

        [BindProperty]
        public DonationmethodModel Donationmethod { get; set; }

        public EditModel(ILookUpClient lookUpClient, IMapper mapper)
        {
            this.lookUpClient = lookUpClient;
            _mapper = mapper;
        }
        public async Task OnGetAsync(int id)
        {
            var result = await lookUpClient.GetDonationmethodByIdCmsAsync(id);

            if (result.Success)
                Donationmethod = _mapper.Map<DonationmethodModel>(result.Result);
        }
        public async Task<JsonResult> OnPostAsync()
        {
            var result = await lookUpClient.EditDonationmethodCmsAsync(new EditDonationmethodCommand()
            {
                Id = Donationmethod.Id,
                NameAr = Donationmethod.NameAr,
                NameEn = Donationmethod.NameEn,
            });
            return new JsonResult(result);
        }
    }
}
