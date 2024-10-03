using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.IntegrationServices;
using WebUI.Models.Provider;

namespace WebUI.Pages.Product
{
    [Authorize(Roles = SystemRoles.ApprovedProduct + " , " + SystemRoles.SuperAdmin)]

    public class ApprovedProductDetailsModel : PageModel
    {
        public IProductClient _productClient { get; set; }
        public string Error { get; set; }
        [BindProperty]
        public GetProductByIdQueryResult ProductDetailsResult { get; set; }
        public ApprovedProductDetailsModel(IProductClient productClient)
        {
            _productClient = productClient;
            ProductDetailsResult = new GetProductByIdQueryResult();
        }
        public async Task<IActionResult> OnGet(Guid productId)
        {
            var result = await _productClient.GetApprovedProductDetailsAsync(productId);

            if (!result.Success)
            {
                Error = result.Errors.FirstOrDefault();
                return RedirectToPage("/Product/index", new { error = Error });
            }

            ProductDetailsResult = result.Result;
           
            return Page();
        }
        [HttpGet]
        public async Task<IActionResult> OnGetDownloadFile(string productId, string fileId)
        {

            var file = await _productClient.GetProductFileByIdCMSAsync(Guid.Parse(productId), Guid.Parse(fileId));
            return new OkObjectResult(file);

        }
    }
}
