using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Models.City;
using WebUI.Models.FirstSubclass;
using WebUI.Models.GovernanceClassification;

namespace WebUI.Pages.FirstSubclass
{
    public class EditModel : PageModel
    {
        public ILookUpClient lookUpClient { get; set; }
        private readonly IMapper _mapper;

        [BindProperty]
        public FirstSubclassModel FirstSubclassModel { get; set; }

        public EditModel(ILookUpClient lookUpClient, IMapper mapper)
        {
            this.lookUpClient = lookUpClient;
            _mapper = mapper;
        }
        public async Task OnGetAsync(Guid id)
        {
            var result = await lookUpClient.GetFirstSubclassCmsGetAsync(id);

            if (result.Success)
                FirstSubclassModel = _mapper.Map<FirstSubclassModel>(result.Result);
        }
        public async Task<JsonResult> OnPostAsync()
        {
            var result = await lookUpClient.EditFirstSubclassCmsAsync(new EditFirstSubclassCommand()
            {
                Id = FirstSubclassModel.Id,
                NameAr = FirstSubclassModel.NameAr,
                NameEn = FirstSubclassModel.NameEn,
            });
            return new JsonResult(result);
        }
    }
}
