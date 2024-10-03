using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Models.contactusDto;
using WebUI.Models.SocialMedia;

namespace WebUI.Pages.SocialMedia
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public SocialMediaModel SocialMedia { get; set; }
        public IWaqfyContentClient _WaqfyContentClient { get; set; }
        public IMapper _mapper { get; set; }

        public IndexModel(IWaqfyContentClient waqfyContentClient, IMapper mapper)
        {
            _WaqfyContentClient = waqfyContentClient;
            _mapper = mapper;
        }

        public void OnGet()
        {
            var result = _WaqfyContentClient.GetAllAsync(WaqfyContentType._3).Result.Result.ToList();

            SocialMedia = _mapper.Map<SocialMediaModel>(result);

        }

        public async Task<JsonResult> OnPost()
        {
            var list = new List<Details>()
            {
                new Details() { ContentKey="FaceBook",ContentValue=SocialMedia.FaceBook},
                new Details() { ContentKey="Twitter",ContentValue=SocialMedia.Twitter},
                new Details() { ContentKey="Instgram",ContentValue=SocialMedia.Instragram},
                new Details() { ContentKey="SnapChat",ContentValue=SocialMedia.SnapChat},


            };

            var result = await _WaqfyContentClient.UpdateAsync(new WaqfyContentCommand() { ContentType = WaqfyContentType._3, Details = list });


            return new JsonResult(result);
        }
    }
}
