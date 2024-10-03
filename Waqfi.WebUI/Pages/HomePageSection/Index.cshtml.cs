using AutoMapper;
using DocumentFormat.OpenXml;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.IntegrationServices;
using WebUI.Models.HomePage;

namespace WebUI.Pages.HomePageSection
{
    [Authorize(Roles = SystemRoles.HomePageList + " , " + SystemRoles.SuperAdmin)]

    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<HomePageModel> HomePageModel { get; set; }

        private readonly IConfiguration _configuration;
        private readonly IWaqfyContentClient _waqfyContent;

        public IWaqfyContentClient WaqfyContentClient { get; set; }
        public IMapper _mapper { get; set; }

        public IndexModel(IWaqfyContentClient waqfyContentClient, IMapper mapper, IConfiguration configuration, IWaqfyContentClient waqfyContent)
        {
            WaqfyContentClient = waqfyContentClient;
            _mapper = mapper;
            _configuration = configuration;
            _waqfyContent = waqfyContent;
        }
        public void OnGet()
        {
            var result = WaqfyContentClient.GetAllAsync(WaqfyContentType._5).Result.Result.ToList();


            HomePageModel = result.Select(e => new Models.HomePage.HomePageModel()
            {
                HomePageKey = e.ContentKey,
                IsHidden= e.ContentValue.ToLowerInvariant(),
                id= e.Id,
            }).ToList();

        }
        public async Task<JsonResult> OnPostChangeStues(int SectionId, bool ActiveOrDeactive)
        {
            var GetResult = await _waqfyContent.UpdateHomePageAsync(SectionId, ActiveOrDeactive == true ? false :true );

            return new JsonResult(GetResult);
        }
    }
}
