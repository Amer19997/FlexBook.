using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Client;
using WebUI.IntegrationServices;
using WebUI.Models.Donator;
using WebUI.ViewModel;

namespace WebUI.Pages.Dondator
{
    [Authorize(Roles = SystemRoles.ViewDonatorList + " , " + SystemRoles.SuperAdmin)]
    public class DonatorsModel : PageModel
    {
        private readonly IDonatorClient _donatorClient;
        public List<Donators> Donators;

        private readonly ILogger<DonatorsModel> _logger;

        public GetDonatorListResult GetDonatorListResult { get; set; }
        public DonatorsModel(ILogger<DonatorsModel> logger, IDonatorClient donatorClient)
        {
            _logger = logger;
            _donatorClient = donatorClient;
            GetDonatorListResult= new GetDonatorListResult();
        }

        public async Task OnGet()
        {
            GetDonatorListResult =await _donatorClient.GetAllDonatorAsync("","","",0);
        }


        public async Task<JsonResult> OnPostGetAjaxAsync(string Donatorname, string Email, string Phone)
        {
            var PageNumber = int.Parse(Request.Form["draw"]);
            var skip = int.Parse(Request.Form["start"]);

           
            var Questions = await _donatorClient.GetAllDonatorAsync(donatorName: Donatorname == null ? Donatorname : Donatorname.Trim(), email: Email == null ? Email : Email.Trim(), phoneNumber: Phone == null ? Phone : Phone.Trim()
           , pageNumber: skip);


            var Date = Questions.GetAllDonatorLists.Select(e => new DonatorViewModal()
            {
                FullName = e.FullName,
                Email = e.Email,
                CountryCode = e.CountryCode,
                MobileNumber = $" {e.MobileNumber} ({e.CountryCode})",
                Id = e.Id,
                CreationDate = e.CreationDate.ToString("dd MMM yyy", CultureInfo.CreateSpecificCulture("AR-AR")),
                CounterPage = skip
            }); ;



            var recordsTotal = Questions.TotalCount;

            //  var data = Questions.TotalCount;

            var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, data = Date };

            return new JsonResult(jsonData);


        }


    }
}
