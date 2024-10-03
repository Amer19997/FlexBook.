using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Models.contactusDto;

namespace WebUI.Pages.contactus
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public contactusDto ContactusDto { get; set; }
        public IWaqfyContentClient _WaqfyContentClient { get; set; }
        public IMapper _mapper { get; set; }

        public IndexModel(IWaqfyContentClient waqfyContentClient, IMapper mapper)
        {
            _WaqfyContentClient = waqfyContentClient;
            _mapper = mapper;
        }

        public void OnGet()
        {
            var result = _WaqfyContentClient.GetAllAsync(WaqfyContentType._2).Result.Result.ToList();

            ContactusDto = _mapper.Map<contactusDto>(result);

        }

        public async Task<JsonResult> OnPost()
        {
            var list = new List<Details>()
            {
                new Details() { ContentKey="AddressAr",ContentValue=ContactusDto.AddressAr},
                new Details() { ContentKey="AddressEn",ContentValue=ContactusDto.AddressEn},
                new Details() { ContentKey="phone",ContentValue=ContactusDto.phone},
                new Details() { ContentKey="location",ContentValue=ContactusDto.location},
            

            };

            var result = await _WaqfyContentClient.UpdateAsync(new WaqfyContentCommand() { ContentType = WaqfyContentType._2, Details = list });


            return new JsonResult(result);
        }
    }
}
