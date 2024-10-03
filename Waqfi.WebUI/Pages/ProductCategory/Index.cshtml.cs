using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Helpers;

namespace WebUI.Pages.ProductCategory
{
    public class IndexModel : PageModel
    {
        private readonly ILookUpClient _lookupClient;
        private readonly IAppSettingService _appSettingService;
        public ProductCategoryDtoPaginatedList ProductCategories { get; set; }
        public IndexModel(ILookUpClient lookupClient, IAppSettingService appSettingService)
        {
            _lookupClient = lookupClient;
            _appSettingService = appSettingService;
        }
        public async Task OnGetAsync(int p)
        {
            var result = (await _lookupClient.GetProductCategoriesAsync(_appSettingService.Pager_PageSize, p == 0 ? 1 : p));
            if (result.Success)
                ProductCategories = result.Result;
        }

        public async Task<PartialViewResult> OnPostSearch(int? p = 0)
        {
            var result = (await _lookupClient.GetProductCategoriesAsync(_appSettingService.Pager_PageSize, p == 0 ? 1 : p));
            return Partial("_ProductCategoryList", result.Result);
        }

        public async Task<ActionResult> OnPostDelete(Guid categoryId)
        {
            var result = await _lookupClient.DeleteProductCategoryAsync(categoryId);
            return new JsonResult(result);
        }
    }
}
