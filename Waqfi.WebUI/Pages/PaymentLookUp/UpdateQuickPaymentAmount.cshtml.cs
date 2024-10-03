using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Models.Payment;

namespace WebUI.Pages.PaymentLookUp
{
    public class UpdateQuickPaymentAmountModel : PageModel
    {

        public ILookUpClient lookUpClient { get; set; }
        private readonly IMapper _mapper;


        public QuickPaymentAmount item { get; set; }
        [BindProperty]
        public QuickPaymentAmountDto itemDto { get; set; }

        public UpdateQuickPaymentAmountModel(ILookUpClient lookUpClient, IMapper mapper)
        {
            this.lookUpClient = lookUpClient;
            _mapper = mapper;
        }
        public async Task OnGetAsync(int id)
        {
            var result = await lookUpClient.GetQuickPaymentAmountItemAsync(id);

            if (result.Success)
            {
                item = result.Result;
                itemDto = _mapper.Map<QuickPaymentAmountDto>(item);
            }
        }
        public async Task<JsonResult> OnPostAsync()
        {
            var result = await lookUpClient.UpdateQuickPaymentAmountItemAsync(new UpdateQuickPaymentAmountItemCommand()
            {
                Id = itemDto.Id,
                Amount = double.Parse(itemDto.Amount.ToString())
            });

            return new JsonResult(result);
        }

    }
}
