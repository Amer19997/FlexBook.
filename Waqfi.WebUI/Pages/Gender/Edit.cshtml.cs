using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Models.City;
using WebUI.Models.FirstSubclass;
using WebUI.Models.Gender;
using WebUI.Models.GovernanceClassification;

namespace WebUI.Pages.Gender
{
    public class EditModel : PageModel
    {
        public ILookUpClient lookUpClient { get; set; }
        private readonly IMapper _mapper;

        [BindProperty]
        public GenderModel GenderModel { get; set; }

        public EditModel(ILookUpClient lookUpClient, IMapper mapper)
        {
            this.lookUpClient = lookUpClient;
            _mapper = mapper;
        }
        public async Task OnGetAsync(int id)
        {
            var result = await lookUpClient.GetGenderCmsGetAsync(id);

            if (result.Success)
                GenderModel = _mapper.Map<GenderModel>(result.Result);
        }
        public async Task<JsonResult> OnPostAsync()
        {
            var result = await lookUpClient.EditGenderCmsAsync(new EditGenderCommand()
            {
                Id = GenderModel.Id,
                NameAr = GenderModel.NameAr,
                NameEn = GenderModel.NameEn,
            });
            return new JsonResult(result);
        }
    }
}
