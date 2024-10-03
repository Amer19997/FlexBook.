using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.IntegrationServices;
using WebUI.Models.AwqafProduct;

namespace WebUI.Pages.productWagfyTest
{
    [Authorize(Roles = SystemRoles.ViewAwqafProductRequests + " , " + SystemRoles.SuperAdmin)]
    public class RequestDetaliesModel : PageModel
    {
        private readonly IAwqafProductClient _awqafProduct;
        public RequestDetaliesModel(IAwqafProductClient awqafProduct)
        {
            _awqafProduct = awqafProduct;
        }

        [BindProperty]
        public RequestWagfiRejectionModel RequestRejectionModel { get; set; }

        [BindProperty(SupportsGet = true)]
        public RequestDetaliesDto RequestDetaliesDto { get; set; }

        public async Task<IActionResult> OnGet(Guid RequestId)
        {
            var result =  _awqafProduct.GetRequestDetailesAsync(RequestId);
            if (result.Result.Success)
                RequestDetaliesDto = new RequestDetaliesDto()
                {
                   RequestId= result.Result.Result.RequestId,
                    Amount= result.Result.Result.Amount,
                    DonatorName=result.Result.Result.DonatorName,   
                    Email= result.Result.Result.Email,
                    MasarName = result.Result.Result.MasarName,
                    Phone = result.Result.Result.Phone,
                    ProductName= result.Result.Result.ProductName,
                    SendRequest=result.Result.Result.SendRequest,
                    statues=(int)result.Result.Result.Status,
                    StatusAsString=result.Result.Result.StatusAsString
                    
                   
                    
                   
                };
            RequestRejectionModel = new() { RequestId = result.Result.Result.RequestId.ToString() };

            return Page();
        }

        public async Task<JsonResult> OnPostRejectRequest()
        {
            var convertRequestId = Guid.Parse(RequestRejectionModel.RequestId.Replace("'", ""));

            var result = await _awqafProduct.RejectRequestAsync(new RejectProductCommand()
            {
                Notes = RequestRejectionModel.Notes?.Trim(),
                ProductId = convertRequestId
            });

            return new JsonResult(result);
        }
    }
}
