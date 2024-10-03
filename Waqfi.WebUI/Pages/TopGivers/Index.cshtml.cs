using System.Text;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Spreadsheet;
using Fingers10.ExcelExport.ActionResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Client;
using WebUI.Helpers;
using WebUI.IntegrationServices;
using WebUI.Models.TopGivers;
using WebUI.ViewModel;

namespace WebUI.Pages.TopGivers;


[Authorize(Roles = SystemRoles.TopGiverDonationViewList + " , " + SystemRoles.SuperAdmin)]
public class IndexModel : PageModel
{
    private readonly ITopGiversClient _topgivers;
    private readonly IOfflineDonationClient _OfflineDonation;
    private readonly IAppSettingService _appSettingService;
    public readonly ILookUpClient _lookUpClient;
    public int PageSize { get; set; }
    public int? PageNumber { get; set; }
    public int TotalCount { get; set; }
    [BindProperty]
    public TopGiversSearch Filters { get; set; }
    //public GetProviderProductsResultListTResponse Products { get; set; }
    public GetOfflineProductDonatorsLookupQueryResult LookupProd { get; set; }
    [BindProperty]
    public GetTopGiversListResult topgivers { get; set; }
    public TopGiversDTO TopGiversDTO { get; set; }
    public IndexModel(ITopGiversClient topgivers, IAppSettingService appSettingService, IOfflineDonationClient offlinedonation, ILookUpClient lookUpClient)
    {
        _topgivers = topgivers;
        _appSettingService = appSettingService;
        _OfflineDonation = offlinedonation;
        _lookUpClient = lookUpClient;
    }
    public async Task OnGetAsync(int p)
    {
        PageNumber = p == 0 ? 1 : p;

        var result = (await _topgivers.GetAllTopGiversAsync(p == 0 ? 1 : p, null, null, null, null));
        //Products = await _OfflineDonation.GetProviderProductsAsync(null);

        var ProductLookups = await _lookUpClient.GetOfflineProductDonatorsLookupsAsync();
        if (ProductLookups.Success)
            LookupProd = ProductLookups.Result;

        PageNumber = p == 0 ? 1 : p;

        TopGiversDTO = new TopGiversDTO()
        {
            PageNumber = PageNumber,
            PageSize = 10,
            TopGiversList = result.Result.Items.ToList(),
            TotalCount = result.Result.TotalCount
        };
        TempData["SearchFilter"] = null;


    }

    public async Task<PartialViewResult> OnPostSearch(int? p = 0)
    {
        if (p != 0)
            Filters = JsonConvert.DeserializeObject<TopGiversSearch>((string)TempData["SearchFilter"] ?? "{}") ?? new TopGiversSearch();

        TempData["SearchFilter"] = JsonConvert.SerializeObject(Filters);

        var result = (await _topgivers.GetAllTopGiversAsync(p == 0 ? 1 : p, null, Filters?.Name?.Trim(), Filters?.phone?.Trim(), Filters?.providerProducts?.ID?.Trim()));

            TopGiversDTO = new TopGiversDTO()
        {
            PageNumber = p == 0 ? 1 : p,
            PageSize = 10,
            TopGiversList = result.Result.Items.ToList(),
            TotalCount = result.Result.TotalCount
        };
        return Partial("TopGiversList", TopGiversDTO);
    }

    [HttpGet]
    public async Task<IActionResult> OnGetDownloadImage(string TopGiversDonation)
    {

        var file = await _topgivers.FileArrayByIdAsync(Guid.Parse(TopGiversDonation));
        return new OkObjectResult(file);


    }





}
