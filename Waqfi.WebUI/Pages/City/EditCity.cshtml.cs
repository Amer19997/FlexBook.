using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Models.City;
using WebUI.Models.Region;

namespace WebUI.Pages.City
{
    public class EditCityModel : PageModel
    {
        public ILookUpClient lookUpClient { get; set; }
        private readonly IMapper _mapper;

        [BindProperty]
        public CityModel CityModel { get; set; }

        public List<GetAllRegionDropDownQueryResult> RegtionList { get; set; }

        public EditCityModel(ILookUpClient lookUpClient, IMapper mapper)
        {
            this.lookUpClient = lookUpClient;
            _mapper = mapper;
        }
        public async Task OnGetAsync(Guid id)
        {
            var result = await lookUpClient.GetCityCmsGetAsync(id);
            RegtionList = lookUpClient.GetRegionDropDowmCmsAsync().Result.Result.ToList();

            if (result.Success)
                CityModel = _mapper.Map<CityModel>(result.Result);
        }
        public async Task<JsonResult> OnPostAsync()
        {
            var result = await lookUpClient.EditCityCmsAsync(new EditCityCommand()
            {
                Id = CityModel.Id,
                NameAr = CityModel.NameAr,
                NameEn = CityModel.NameEn,
                CountryId = CityModel.CountryId
            });
            return new JsonResult(result);
        }
    }
}
