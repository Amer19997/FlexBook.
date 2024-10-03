using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.IntegrationServices;
using WebUI.Models.Product;
using WebUI.Models.ProductBanner;
using WebUI.Models.Provider;

namespace WebUI.Pages.ProductBanner
{
    [Authorize(Roles = SystemRoles.Banner + " , " + SystemRoles.SuperAdmin)]
    public class ProductDetaliesModel : PageModel
    {
        public IProduectBannerClient _productClient { get; set; }
        public IProductClient _productsClient { get; set; }


        public string Error { get; set; }

        [BindProperty]
        public ProductBannerRequestApproveModel RequestApprovalModel { get; set; }

        [BindProperty]
        public ProductBannerRequestRejectionModel RequestRejectionModel { get; set; }
        public GetApproveDetaliesQueryResult ProductDetailsResult { get; set; }

      

        public GetSocietyDetailsQueryResult SocietyDetails { get; set; }
        public ProductDetaliesModel(ILookUpClient lookUpClient, IProduectBannerClient productClient, IProductClient productsClient)
        {

            _productClient = productClient;
            ProductDetailsResult = new GetApproveDetaliesQueryResult() { };
            _productsClient = productsClient;
        }
        public async Task<IActionResult> OnGet(Guid productId)
        {
            var result = await _productClient.GetProductApproveCmsAsync(productId);

            if (!result.Success)
            {
                Error = result.Errors.FirstOrDefault();
                return RedirectToPage("/ProductBanner/index", new { error = Error });
            }

            ProductDetailsResult = result.Result;
            RequestApprovalModel = new() { ProductId = productId };
            RequestRejectionModel = new() { RequestId = productId.ToString() };



            return Page();
        }

        public async Task<JsonResult> OnPostRejectRequest()
        {
            var convertRequestId = Guid.Parse(RequestRejectionModel.RequestId.Replace("'", ""));

            var result = await _productClient.RejectProductBannerRequestAsync(new RejectAddProductBannerCommand()
            {
                Notes = RequestRejectionModel.Notes?.Trim(),
                ProductId = convertRequestId
            });

            return new JsonResult(result);
        }
        public async Task<JsonResult> OnPostApproveRequest()
        {
            
            if (RequestApprovalModel.Publishdate.Equals(DateTime.DaysInMonth))
            {
                return new JsonResult(RequestApprovalModel);
            }
            var result = await _productClient.ApproveProductBannerRequestAsync(
                    new ApproveRequestProductCommand
                    {
                        ProductId = RequestApprovalModel.ProductId,
                        Publishdate = DateTimeOffset.Parse(RequestApprovalModel.Publishdate),
                        Disappearancedate =RequestApprovalModel.Disappearancedate != null ? DateTimeOffset.Parse(RequestApprovalModel.Disappearancedate) :null,
                        Priority = RequestApprovalModel.priority 

                    });

            return new JsonResult(result);
           }
        [HttpGet]
        public async Task<IActionResult> OnGetDownloadFile(string productId, string fileId)
        {

            var file = await _productsClient.GetProductFileByIdCMSAsync(Guid.Parse(productId), Guid.Parse(fileId));
            return new OkObjectResult(file);

        }

        [HttpGet]
        public async Task<IActionResult> OnGetDownloadImage(string productId, string fileId)
        {

            var file = await _productsClient.GetProductImageByIdAsync(Guid.Parse(productId), Guid.Parse(fileId));
            return new OkObjectResult(file);
        }
    }
}
