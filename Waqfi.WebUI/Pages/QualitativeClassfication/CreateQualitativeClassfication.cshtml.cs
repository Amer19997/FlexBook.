using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Models.QualitativeClassfication;

namespace WebUI.Pages.QualitativeClassfication
{
    public class CreateQualitativeClassficationModel : PageModel
    {
        public readonly ILookUpClient _lookUpClient;
        public IMapper _mapper;

        [BindProperty]
        public CreateQualitativeClassfication createModel { get; set; }


        public CreateQualitativeClassficationModel(ILookUpClient lookUpClient, IMapper mapper)
        {
            _lookUpClient = lookUpClient;
            _mapper = mapper;
        }
        public async Task OnGet()
        {

            
        }
        public async Task<JsonResult> OnPostAsync()
        {
            var command = _mapper.Map<AddQualitativeClassificationsCommand>(createModel);
            var result = await _lookUpClient.AddNewQualitativeClassificationAsync(command);
            return new JsonResult(result);
        }
    }
}
