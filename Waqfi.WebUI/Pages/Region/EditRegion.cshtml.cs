using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Models.ProductUnit;
using WebUI.Models.Region;

namespace WebUI.Pages.Region
{
    public class EditRegionModel : PageModel
    {
       
        public ILookUpClient lookUpClient { get; set; }
        private readonly IMapper _mapper;

        [BindProperty]
        public RegionModel RegionModel { get; set; }
        public EditRegionModel(ILookUpClient  lookUpClient, IMapper mapper)
        {
            this.lookUpClient = lookUpClient;
            _mapper = mapper;
        }
        public async Task OnGetAsync(Guid id)
        {
            var result = await lookUpClient.GetRegionCmsGetAsync(id);
            if (result.Success)
                RegionModel = _mapper.Map<RegionModel>(result.Result);
        }
        public async Task<JsonResult> OnPostAsync()
        {
            var result = await lookUpClient.EditRegionCmsAsync(new EditRegionCommand()
            {
                Id = RegionModel.Id,
                NameAr = RegionModel.NameAr,
                NameEn = RegionModel.NameEn,
                 PostalCode= RegionModel.PostalCode
            });
            return new JsonResult(result);
        }
    }
}
