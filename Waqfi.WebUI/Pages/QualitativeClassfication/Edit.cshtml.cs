using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Models.QualitativeClassfication;

namespace WebUI.Pages.QualitativeClassfication
{
    public class EditModel : PageModel
    {
        public readonly ILookUpClient _lookUpClient;
        public IMapper _mapper;
        [BindProperty]
        public EditQualitativeClassfication item { get; set; }
        public EditModel(ILookUpClient lookUpClient, IMapper mapper)
        {
            _lookUpClient = lookUpClient;
            _mapper = mapper;
        }
        public async Task OnGet(Guid id)
        {
            var entityResult = (await _lookUpClient.GetQualitativeClassificationItemAsync(id)).Result;
            item = _mapper.Map<EditQualitativeClassfication>(entityResult);
        }
        public async Task<JsonResult> OnPostAsync()
        {
            var command = _mapper.Map<EditQualitativeClassificationsCommand>(item);
            var result = await _lookUpClient.EditQualitativeClassificationAsync(command);
            return new JsonResult(result);
        }
    }
}
