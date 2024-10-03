using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Helpers;
using WebUI.IntegrationServices;

namespace WebUI.Pages.ProductUnits
{
    [Authorize(Roles = SystemRoles.ViewProductUnitList + " , " + SystemRoles.SuperAdmin)]
    public class IndexModel : PageModel
    {
        private readonly IProductUnitClient _productUnitClient;
        private readonly IAppSettingService _appSettingService;
        public ProductUnitDtoPaginatedList ProductUnits { get; set; }
        public IndexModel(IProductUnitClient productUnitClient, IAppSettingService appSettingService)
        {
            _productUnitClient = productUnitClient;
            _appSettingService = appSettingService;
        }
        public async Task OnGetAsync(int p)
        {
            var result = (await _productUnitClient.ProductUnitGetAsync(_appSettingService.Pager_PageSize, p == 0 ? 1 : p));
            if (result.Success)
                ProductUnits = result.Result;
        }

        public async Task<PartialViewResult> OnPostSearch(int? p = 0)
        {
            var result = (await _productUnitClient.ProductUnitGetAsync(_appSettingService.Pager_PageSize, p == 0 ? 1 : p));
            return Partial("_ProductUnitList", result.Result);
        }

        public async Task<ActionResult> OnPostDelete(Guid unitId)
        {
            var result = await _productUnitClient.ProductUnitDeleteAsync(unitId);
            return new JsonResult(result);
        }
    }
}
