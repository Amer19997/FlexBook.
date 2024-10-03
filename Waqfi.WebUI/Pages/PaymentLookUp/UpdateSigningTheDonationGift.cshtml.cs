using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Models.Lookups;

namespace WebUI.Pages.PaymentLookUp
{
    public class UpdateSigningTheDonationGiftModel : PageModel
    {
        public ILookUpClient lookUpClient { get; set; }
        private readonly IMapper _mapper;
        public SigningTheDonationGift item { get; set; }
        [BindProperty]
        public SigningTheDonationGiftDto itemDto {get;set;}

        public UpdateSigningTheDonationGiftModel(ILookUpClient lookUpClient, IMapper mapper)
        {
            this.lookUpClient = lookUpClient;
            _mapper = mapper;
        }
        public async Task OnGetAsync(int id)
        {
            var result = await lookUpClient.GetSigningTheDonationGiftItemAsync(id);

            if (result.Success)
            {
                item = result.Result;
                itemDto = _mapper.Map<SigningTheDonationGiftDto>(item);
            }
        }
        public async Task<JsonResult> OnPostAsync()
        {
            var result = await lookUpClient.UpdateSigningTheDonationGiftAsync(new UpdateSigningTheDonationGiftCommand()
            {
                Id = itemDto.Id,
                NameAr = itemDto.NameAr,
                NameEn = itemDto.NameEn,
            });

            return new JsonResult(result);
        }
    }
}
