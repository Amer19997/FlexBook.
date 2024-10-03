using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Models.City;
using WebUI.Models.GovernanceClassification;

namespace WebUI.Pages.GovernanceClassification
{
    public class EditModel : PageModel
    {
        public ILookUpClient lookUpClient { get; set; }
        private readonly IMapper _mapper;

        [BindProperty]
        public GovernanceClassificationModel ClassificationModel { get; set; }

        public EditModel(ILookUpClient lookUpClient, IMapper mapper)
        {
            this.lookUpClient = lookUpClient;
            _mapper = mapper;
        }
        public async Task OnGetAsync(Guid id)
        {
            var result = await lookUpClient.GetGovernanceClassificationCmsAsync(id);

            if (result.Success)
                ClassificationModel = _mapper.Map<GovernanceClassificationModel>(result.Result);
        }
        public async Task<JsonResult> OnPostAsync()
        {
            var result = await lookUpClient.EditGovernanceClassificationCmsAsync(new EditGovernanceClassificationCommand()
            {
                Id = ClassificationModel.Id,
                NameAr = ClassificationModel.NameAr,
                NameEn = ClassificationModel.NameEn,
            });
            return new JsonResult(result);
        }
    }
}
