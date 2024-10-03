using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Client;
using WebUI.Helpers;
using WebUI.IntegrationServices;
using WebUI.Models.contactusDto;
using WebUI.Models.Provider;

namespace WebUI.Pages.ContactUsRequest
{
    [Authorize(Roles = SystemRoles.ContactUsList + " , " + SystemRoles.SuperAdmin)]

    public class IndexModel : PageModel
    {
        public string Error { get; set; }
        private readonly IAppSettingService _appSettingService;
        private readonly IContactUsClient _contactUsClient;

        public List<Int32LookupDto> ContactUsTypes { get; set; }
        public List<Int32LookupDto> ContactUsStatus { get; set; }
        [BindProperty(SupportsGet = true)]
        public GetContactUsListCmsQueryResultPaginatedList ContactUs { get; set; }
        [BindProperty]
        public ContactUsRequestSearchModel Filter { get; set; }


        public IndexModel(IAppSettingService appSettingService, IContactUsClient contactUsClient)
        {
            _appSettingService = appSettingService;
            _contactUsClient = contactUsClient;
        }
        public async Task OnGetAsync(int p, string error)
        {
            Error = error;
            var result = (await _contactUsClient.GetContactUsCmsListAsync( null,null,null,null,_appSettingService.Pager_PageSize, p == 0 ? 1 : p));
            if (result.Success)
                ContactUs = result.Result;


            ContactUsTypes = (await _contactUsClient.GetContactUsTypesAsync()).Result.ToList();

            ContactUsStatus = (await _contactUsClient.GetContactUsStatusAsync()).Result.ToList();

            TempData["SearchFilter"] = null;
        }

        public async Task<PartialViewResult> OnPostSearch(int? p = 0)
        {
            if (p != 0)
                Filter = JsonConvert.DeserializeObject<ContactUsRequestSearchModel>((string)TempData["SearchFilter"] ?? "{}") ?? new ContactUsRequestSearchModel();

            TempData["SearchFilter"] = JsonConvert.SerializeObject(Filter);

            var result = (await _contactUsClient.GetContactUsCmsListAsync(Filter.RequestNumber, Filter.Status, Filter.Type, Filter.Contains, _appSettingService.Pager_PageSize, p == 0 ? 1 : p));
            return Partial("_ContactUsRequestList", result.Result);
        }
    }
}
