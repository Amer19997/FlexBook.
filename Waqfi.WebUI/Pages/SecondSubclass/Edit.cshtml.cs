using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Models.City;
using WebUI.Models.FirstSubclass;
using WebUI.Models.GovernanceClassification;
using WebUI.Models.SecondSubclass;

namespace WebUI.Pages.SecondSubclass
{
    public class EditModel : PageModel
    {
        public ILookUpClient lookUpClient { get; set; }
        private readonly IMapper _mapper;

        [BindProperty]
        public SecondSubclassModel SecondSubclassModel { get; set; }

        public EditModel(ILookUpClient lookUpClient, IMapper mapper)
        {
            this.lookUpClient = lookUpClient;
            _mapper = mapper;
        }
        public async Task OnGetAsync(Guid id)
        {
            var result = await lookUpClient.GetSecondSubclassCmsAsync(id);

            if (result.Success)
                SecondSubclassModel = _mapper.Map<SecondSubclassModel>(result.Result);
        }
        public async Task<JsonResult> OnPostAsync()
        {
            var result = await lookUpClient.EditSecondSubclassclassCmsAsync(new EditSecondSubclassCommand()
            {
                Id = SecondSubclassModel.Id,
                NameAr = SecondSubclassModel.NameAr,
                NameEn = SecondSubclassModel.NameEn,
            });
            return new JsonResult(result);
        }
    }
}
