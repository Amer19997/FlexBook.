using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Client;
using WebUI.Filters;
using WebUI.Helpers;
using WebUI.IntegrationServices;
using WebUI.Models.ApprovedProduct;
using WebUI.Models.Banner;

namespace WebUI.Pages.Banner
{
    [Authorize(Roles = SystemRoles.Banner + " , " + SystemRoles.SuperAdmin)]
    public class IndexModel : PageModel
    {
        public string Error { get; set; }
        private readonly IAppSettingService _appSettingService;
        private readonly IBannerClient _BannerClient;
        public int PageSize { get; set; }
        public int? PageNumber { get; set; }
        public int TotalCount { get; set; }
        public BannersDto BannerRequest { get; set; }
      
  

        public IndexModel(IAppSettingService appSettingService, IBannerClient bannerClient)
        {
            _appSettingService = appSettingService;
            PageSize = _appSettingService.Pager_PageSize;
            _BannerClient = bannerClient;
        }

        public async Task OnGet(int p, string error)
        {
            PageNumber = p == 0 ? 1 : p;

            var result = await _BannerClient.GetAllBannersCMSAsync(_appSettingService.Pager_PageSize, p == 0 ? 1 : p);


            BannerRequest = new BannersDto()
            {
                PageNumber = PageNumber,
                PageSize = PageSize,
                TotalCount = result.Result.TotalCount,
                BanneritemsDto = result.Result.BannerItemsDTO.ToList()
            };

        }


        public async Task<PartialViewResult> OnPost(int? p = 0)
        {
            var result = await _BannerClient.GetAllBannersCMSAsync(_appSettingService.Pager_PageSize, p == 0 ? 1 : p);


            PageNumber = p;

            BannerRequest = new BannersDto()
            {
                PageNumber = PageNumber,
                PageSize = PageSize,
                TotalCount = result.Result.TotalCount,
                BanneritemsDto = result.Result.BannerItemsDTO.ToList()
            };

            return Partial("_BannerList", BannerRequest);
        }

        [HttpGet]
        public async Task<IActionResult> OnGetDeleteBanner(string BannerId)
        {
            var ConvBannerId = Guid.Parse(BannerId);

            var Result = await _BannerClient.DeleteBannerCMSAsync(ConvBannerId);
            return new OkObjectResult(Result);

        }

    }
}
