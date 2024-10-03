using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Client;
using WebUI.Filters;
using WebUI.Helpers;
using WebUI.IntegrationServices;
using WebUI.Models.Product;


namespace WebUI.Pages.ProductsRequest
{
    [Authorize(Roles = SystemRoles.RequestProducts+" , "+SystemRoles.SuperAdmin)]
    public class IndexModel : PageModel
    {
        public string Error { get; set; }
        private readonly IAppSettingService _appSettingService;
        private readonly IProductClient _productClient;
        public int PageSize { get; set; }
        public int? PageNumber { get; set; }
        public int TotalCount { get; set; }
        public ProductList ProductsRequest { get; set; }
        public GetProductsLookupsQueryResult lookUps { get; set; }
        [BindProperty]
        public filterRequestProductsDto Filters { get; set; }
      

        public IndexModel(IAppSettingService appSettingService, IProductClient productClient)
        {
            _appSettingService = appSettingService;
            this._productClient = productClient;
            PageSize = _appSettingService.Pager_PageSize;   
        }
        public async Task OnGet(int p, string error)
        {
            Error = error;
            PageNumber = p==0 ? 1 : p;
            var GetLookup = await _productClient.GetProductsLookupsAsync();
            if (GetLookup.Success)
                lookUps = GetLookup.Result;

            var result = await _productClient.GetProductsRequestAsync(null, null, null, null, null, null,null,null,null,_appSettingService.Pager_PageSize, p == 0 ? 1 : p);


            ProductsRequest = new ProductList()
            {
                PageNumber = PageNumber,
                PageSize = PageSize,
                ProductsRequest = result.Result.Items.ToList(),
                TotalCount = result.Result.TotalCount
            };
            TempData["SearchFilter"] = null;
        }

        public async Task<PartialViewResult> OnPostSearch(int? p = 0)
        {
            if (p != 0)
                Filters = JsonConvert.DeserializeObject<filterRequestProductsDto>((string)TempData["SearchFilter"] ?? "{}") ?? new filterRequestProductsDto();

            TempData["SearchFilter"] = JsonConvert.SerializeObject(Filters);
            var productResponse = (await _productClient.GetProductsRequestAsync(Filters.ProductName?.Trim(),
                                                                                        Filters.EntityName?.Trim(),
                                                                                        Filters.ProductType,
                                                                                        Filters.Massar,
                                                                                        Filters.City,
                                                                                        null,
                                                                                        Filters.Gender,
                                                                                        Filters.Status,
                                                                                        Filters.Providers==null ? null : Guid.Parse(Filters.Providers),
                                                                                        _appSettingService.Pager_PageSize,
                                                                                        p == 0 ? 1 : p));
          ProductsRequest = new ProductList()
            {
                PageNumber = productResponse.Result.PageNumber,
                PageSize = PageSize,
                ProductsRequest = productResponse.Result.Items.ToList(),
                TotalCount = productResponse.Result.TotalCount
            };

          return  Partial("_ProductRequest", ProductsRequest);
        }

    }
}
