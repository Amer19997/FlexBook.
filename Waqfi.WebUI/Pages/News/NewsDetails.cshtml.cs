using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.IntegrationServices;
using WebUI.Models.News;

namespace WebUI.Pages.News
{
    [Authorize(Roles = SystemRoles.ViewNewsList + " , " + SystemRoles.SuperAdmin)]
    public class NewsDetailsModel : PageModel
    {
        private readonly INewsClient _newsClient;
        private readonly IMapper _mapper;

        [BindProperty]
        public NewsDto NewsDto { get; set; }
        public List<NewsStatusDto> Status { get; set; }

        public NewsDetailsModel(INewsClient newsClient , IMapper mapper)
        {
            _newsClient = newsClient;
            _mapper = mapper;
        }
        public async Task OnGetAsync(Guid id)
        {
            var NewsStatusQueryResult = await _newsClient.StatusAsync(new NewsStatusQuery());
            if (NewsStatusQueryResult.Success)
            {
                Status = NewsStatusQueryResult.Result.Select(ss => new NewsStatusDto
                {
                    Id = ss.Id,
                    NameAr = ss.NameAr,
                    NameEn = ss.NameEn,
                }).ToList();
            }
            var news = await _newsClient.GetCMSNewsAsync(id);
            NewsDto = _mapper.Map<NewsDto>(news.Result);
        }

    }
}
