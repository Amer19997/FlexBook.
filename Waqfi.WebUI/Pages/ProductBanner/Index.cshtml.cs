using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Client;
using WebUI.Filters;
using WebUI.Helpers;
using WebUI.IntegrationServices;
using WebUI.Models.Product;
using WebUI.Models.ProductBanner;
using WebUI.Models.Provider;

namespace WebUI.Pages.ProductBanner
{
    [Authorize(Roles = SystemRoles.Banner + " , " + SystemRoles.SuperAdmin)]
    public class IndexModel : PageModel
    {
        public string Error { get; set; }
        private readonly IAppSettingService _appSettingService;
        private readonly IProduectBannerClient _productbanner;
        private readonly IProviderClient _providerClient;
        
        public IndexModel(IAppSettingService appSettingService, IProduectBannerClient productClient, IProviderClient providerClient)
        {
            _appSettingService = appSettingService;
            _productbanner = productClient;
            _providerClient = providerClient;
        }

        public int PageSize { get; set; }
        public int? PageNumber { get; set; }
        public int TotalCount { get; set; }
        public ProductListBanner ProductsBannerRequest { get; set; }
        public GetProductsLookupsQueryResult lookUps { get; set; }
        [BindProperty]
        public ProductBannerSearch Filters { get; set; }

      
        public async Task OnGet(int p, string error)
        {
            Error = error;
            PageNumber = p == 0 ? 1 : p;
            
            var result = await _productbanner.GetAllProductApproveCmsAsync(null, _appSettingService.Pager_PageSize, p == 0 ? 1 : p);

            ProductsBannerRequest = new ProductListBanner()
            {
                PageNumber = PageNumber,
                PageSize = PageSize,
                ProductsRequest = result.Result.ProductItemDtos.ToList(),
                TotalCount = result.Result.TotalCount

            };
        }

        public async Task<PartialViewResult> OnPostSearch(int? p = 0)
        {
            if (p != 0)
                Filters = JsonConvert.DeserializeObject<ProductBannerSearch>((string)TempData["SearchFilter"] ?? "{}") ?? new ProductBannerSearch();

            TempData["SearchFilter"] = JsonConvert.SerializeObject(Filters);

            var result = (await _productbanner.GetAllProductApproveCmsAsync(Filters.Name?.Trim(), _appSettingService.Pager_PageSize, p == 0 ? 1 : p));

            ProductsBannerRequest = new ProductListBanner()
            {
                PageNumber = p == 0 ? 1 : p,
                PageSize = _appSettingService.Pager_PageSize,
                ProductsRequest = result.Result.ProductItemDtos.ToList(),
                TotalCount = result.Result.TotalCount

            };
            

            return Partial("_ApproveProduct", ProductsBannerRequest);
        }
    }
}
