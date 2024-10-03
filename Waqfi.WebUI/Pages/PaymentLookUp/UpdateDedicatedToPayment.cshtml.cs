using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Models.Lookups;
using WebUI.Models.News;

namespace WebUI.Pages.PaymentLookUp
{
    public class UpdateDedicatedToPaymentModel : PageModel
    {
        public ILookUpClient lookUpClient { get; set; }
        private readonly IMapper _mapper;

        
        public DedicatedToPaymentLookup item { get; set; }
        [BindProperty]
        public DedicatedToPaymentDto itemDto { get; set; }

        public UpdateDedicatedToPaymentModel(ILookUpClient lookUpClient, IMapper mapper)
        {
            this.lookUpClient = lookUpClient;
            _mapper = mapper;
        }
        public async Task OnGetAsync(int id)
        {
            var result = await lookUpClient.GetDedicatedToPaymentItemAsync(id);

            if (result.Success)
            {
                item = result.Result;
                itemDto = _mapper.Map<DedicatedToPaymentDto>(item);
            }
        }
        public async Task<JsonResult> OnPostAsync()
        {
            var result = await lookUpClient.UpdateDedicatedToPaymentAsync(new UpdateDedicatedToPaymentCommand()
            {
                Id = itemDto.Id,
                NameAr = itemDto.NameAr,
                NameEn = itemDto.NameEn,
            });

            return new JsonResult(result);
        }
    }
}
