using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Models.Lookups;

namespace WebUI.Pages.ReportType
{
    public class EditModel : PageModel
    {
        private readonly ILookUpClient _lookupClient;
        private readonly IMapper _mapper;

        [BindProperty]
        public ReportTypeModel ReportType { get; set; }
        public EditModel(ILookUpClient lookupClient, IMapper mapper)
        {
            _lookupClient = lookupClient;
            _mapper = mapper;
        }
        public async Task OnGetAsync(Guid id)
        {
            var result = await _lookupClient.GetReportTypeAsync(id);
            if (result.Success)
                ReportType = _mapper.Map<ReportTypeModel>(result.Result);
        }
        public async Task<JsonResult> OnPostAsync()
        {
            var result = await _lookupClient.EditReportTypeAsync(new EditReportTypeCommand()
            {
                Id = ReportType.Id,
                NameAr = ReportType.NameAr,
                NameEn = ReportType.NameEn
            });
            return new JsonResult(result);
        }

    }
}
