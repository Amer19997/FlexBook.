using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Client;
using WebUI.Filters;
using WebUI.Helpers;
using WebUI.IntegrationServices;
using WebUI.Models.ApprovedProduct;
using WebUI.Models.Product;

namespace WebUI.Pages.ApprovedProducts
{
    [Authorize(Roles = SystemRoles.ApprovedProduct + " , " + SystemRoles.SuperAdmin)]
    public class IndexModel : PageModel
    {
        public string Error { get; set; }
        private readonly IAppSettingService _appSettingService;
        private readonly IProductClient _productClient;
        private readonly ILookUpClient _lookUpClient;

        public int PageSize { get; set; }
        public int? PageNumber { get; set; }
        public int TotalCount { get; set; }
        public ApprovedProductDTO ProductsRequest { get; set; }
        public GetProductsLookupsQueryResult lookUps { get; set; }

        public List<Client.GetProductPaymentStatusItem> ProductTypeResult { get; set; }
        [BindProperty]
        public filterRequestProductsDto Filters { get; set; }

        public IndexModel(IAppSettingService appSettingService, IProductClient productClient, ILookUpClient lookUpClient)
        {
            _appSettingService = appSettingService;
            this._productClient = productClient;
            PageSize = _appSettingService.Pager_PageSize;
            _lookUpClient = lookUpClient;
        }
        public async Task OnGet(int p, string error)
        {
            PageNumber = p == 0 ? 1 : p;
            var GetLookup = await _productClient.GetProductsLookupsAsync();
            ProductTypeResult = (await _lookUpClient.GetProductPaymentStatusAsync()).Result.ProductPaymentList.ToList();

            if (GetLookup.Success)
                lookUps = GetLookup.Result;

            var result = await _productClient.GetApprovedProductsAsync(null, null, null, null, null, null,null,null,   null,null,null ,null,_appSettingService.Pager_PageSize, p == 0 ? 1 : p);


            ProductsRequest = new ApprovedProductDTO()
            {
                PageNumber = PageNumber,
                PageSize = PageSize,
                ProductsRequest = result.Result.ProductItemDtos.ToList(),
                TotalCount = result.Result.TotalCount
            };
            TempData["SearchFilter"] = null;

        }
        public async Task<JsonResult> OnPostAcvtive(Guid UserId,bool ActiveOrDeactive)
        {
            var GetResult = await _productClient.ApperOnHomePageCMSAsync(UserId,(bool)ActiveOrDeactive);
           
            return new JsonResult(GetResult);
        }

        public async Task<JsonResult> OnPostChangeStues(Guid UserId, bool ActiveOrDeactive)
        {
            var GetResult = await _productClient.ChangeProductIsBarallelProductAsync(UserId, (bool)ActiveOrDeactive);

            return new JsonResult(GetResult);
        }
        public async Task<PartialViewResult> OnPostSearch(int? p = 0)
        {
            if (p != 0)
                Filters = JsonConvert.DeserializeObject<filterRequestProductsDto>((string)TempData["SearchFilter"] ?? "{}") ?? new filterRequestProductsDto();

            TempData["SearchFilter"] = JsonConvert.SerializeObject(Filters);
            var productResponse = (await _productClient.GetApprovedProductsAsync(Filters.ProductName?.Trim(),
                                                                                        Filters.EntityName?.Trim(),
                                                                                        Filters.ProductPaymentStatus,
                                                                                        Filters.ProductType,
                                                                                        Filters.Massar,
                                                                                        Filters.City,
                                                                                        Filters.sesson,
                                                                                        Filters.TargetGroup,
                                                                                        Filters.Gender,
                                                                                        Filters.Apperonhomepage,
                                                                                        Filters.BidPercentage,
                                                                                        Filters.IsBarallelProduct==1?true:
                                                                                        Filters.IsBarallelProduct==0?false:null,
                                                                                        _appSettingService.Pager_PageSize,
                                                                                        p == 0 ? 1 : p));
            ProductsRequest = new ApprovedProductDTO()
            {
                PageNumber = p,
                PageSize = PageSize,
                ProductsRequest = productResponse.Result.ProductItemDtos.ToList(),
                TotalCount = productResponse.Result.TotalCount
            };

            return Partial("_ApprovedProduct", ProductsRequest);
        }
    }
}
