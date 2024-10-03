using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Models.City;
using WebUI.Models.Region;

namespace WebUI.Pages.City
{
    public class AddCityModel : PageModel
    {
        private readonly ILookUpClient _lookup;

        public AddCityModel(ILookUpClient lookup)
        {
            _lookup = lookup;
        }

        [BindProperty]
        public CityModel CityModel { get; set; }
        public List<GetAllRegionDropDownQueryResult> RegtionList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            RegtionList = _lookup.GetRegionDropDowmCmsAsync().Result.Result.ToList();
            return Page();
        }

        public async Task<JsonResult> OnPostAsync()
        {
            var result = await _lookup.AddCityCmsAsync(new AddCityCommand()
            {
                NameAr = CityModel.NameAr,
                NameEn = CityModel.NameEn,
                CountryId = CityModel.CountryId
            });
            return new JsonResult(result);
        }
    }
}
