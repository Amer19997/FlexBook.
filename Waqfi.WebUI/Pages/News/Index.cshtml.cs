using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Client;
using WebUI.Helpers;
using WebUI.IntegrationServices;
using WebUI.Models.News;

namespace WebUI.Pages.News
{
    [Authorize(Roles = SystemRoles.ViewNewsList + " , " + SystemRoles.SuperAdmin)]
    public class IndexModel : PageModel
    {
        private readonly INewsClient _newsClient;

        private readonly IAppSettingService _appSettingService;

        public int PageSize { get; set; }
        public int? PageNumber { get; set; }
        public int TotalCount { get; set; }

        public NewsList NewsList { get; set; }
        [BindProperty]
        public filterNewsDto Filters { get; set; }
        public List<NewsStatusDto> Status { get; set; }
        public IndexModel(INewsClient newsClient,IAppSettingService appSettingService)
        {
            _newsClient = newsClient;
            NewsList = new NewsList();
            _appSettingService = appSettingService;
        }

        public async Task OnGet(int p)
        {
            await GetNews(p);
            TempData["SearchFilter"] = null;
        }

        public async Task<PartialViewResult> OnPostSearch(int? p = 0)
        {
            if (p != 0)
                Filters = JsonConvert.DeserializeObject<filterNewsDto>((string)TempData["SearchFilter"] ?? "{}") ?? new filterNewsDto();

            TempData["SearchFilter"] = JsonConvert.SerializeObject(Filters);
            await GetNews(p);
            return Partial("_NewsList", NewsList);
        }
        private async Task<NewsList> GetNews(int? p = 0)
        {
            PageNumber = p == 0 ? 1 : p;
            var NewsStatusQueryResult =await _newsClient.StatusAsync(new NewsStatusQuery());
            if (NewsStatusQueryResult.Success)
            {
                Status = NewsStatusQueryResult.Result.Select(ss => new NewsStatusDto
                {
                    Id = ss.Id,
                    NameAr = ss.NameAr,
                    NameEn = ss.NameEn,
                }).ToList();
            }
            NewsQueryResult res = await _newsClient.GetNewsAsync(p == 0 ? 1 : p, Filters?.Title, Filters?.Status);
            NewsList = new NewsList
            {
                NewsViewModals = res.News.Select(d => new NewsViewModal
                {
                    DetailsAr = d.DetailsAr,
                    DetailsEn = d.DetailsEn,
                    NewsId = d.NewsId,
                    PublishDate = d.PublishDate,
                    StatusNameAr = d.StatusNameAr,
                    StatusNameEn = d.StatusNameEn,
                    SummaryAr = d.SummaryAr,
                    SummaryEn = d.SummaryEn,
                    TitleAr = d.TitleAr,
                    TitleEn = d.TitleEn,
                }).ToList(),
                TotalCount = res.TotalCount,
                PageNumber = PageNumber,
                PageSize = _appSettingService.Pager_PageSize,
            };
            return NewsList;
        }

        public async Task<ActionResult> OnPostDelete(Guid newsId)
        {
            var result = await _newsClient.NewsAsync(newsId);
            return new JsonResult(result);
        }
    }
}
