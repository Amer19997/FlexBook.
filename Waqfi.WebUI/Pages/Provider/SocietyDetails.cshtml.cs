using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.IntegrationServices;
using WebUI.Models.Provider;

namespace WebUI.Pages.Provider
{
    [Authorize(Roles = SystemRoles.ViewProvidersRequestsList + " , " + SystemRoles.SuperAdmin)]
    public class SocietyDetailsModel : PageModel
    {
        public ISocietyClient _societyClient { get; set; }
        public IAssociationsClient _associationsClient { get; set; }
        public IProviderClient _ProviderClient { get; set; }
        public GetSocietyDetailsQueryResult SocietyDetails { get; set; }
        public string Error { get; set; }
        public string SocietyId { get; set; }
        public List<StepDto> Steps { get; set; }
        [BindProperty]
        public RequestApprovalModel RequestApprovalModel { get; set; }
        [BindProperty]
        public RequestRejectionModel RequestRejectionModel { get; set; }

        [BindProperty]
        public RequestReturnModel RequestReturnModel { get; set; }

        public SocietyDetailsModel(ISocietyClient societyClient, IProviderClient providerClient, IAssociationsClient associationsClient)
        {
            _societyClient = societyClient;
            _ProviderClient = providerClient;
            _associationsClient= associationsClient;
            Steps = new List<StepDto>();
        }
        public async Task<IActionResult> OnGet(string socityId)
        {
            
            var result = await _societyClient.GetSocietyDetailsAsync(Guid.Parse(socityId));

            if (!result.Success)
            {
                Error = result.Errors.FirstOrDefault();
                return RedirectToPage("/Provider/ProvidersRequests", new { error = Error });
            }

            SocietyDetails = result.Result;
            RequestApprovalModel = new() { Id = new Guid(socityId) };
            RequestRejectionModel = new() { RequestId = new Guid(socityId) };
            RequestReturnModel = new() { RequestId = new Guid(socityId) };
            RequestReturnModel.Steps = (await _societyClient.GetSocietyStepsAsync()).Result.ToList();
            return Page();
        }

        public async Task<IActionResult> OnGetDownloadFile(string id,string requestId)
        {
            var file = await _societyClient.FileArrayByIdAsync(
                       Guid.Parse(requestId),
                       Guid.Parse(id)
                       );

            return new OkObjectResult(file);

            // return JsonResult(null);
        }

        public async Task<JsonResult> OnPostRejectRequest()
        {
            var result = await _ProviderClient.RejectRequestAsync(
                                new RejectRequestCommand
                                {
                                    Note = RequestRejectionModel.Notes,
                                    RequestId =RequestRejectionModel.RequestId
                                });

            return new JsonResult(result);
        }
        public async Task<JsonResult> OnPostReturnRequest()
        {
            var result = await _ProviderClient.ReturnRequestAsync(
                                new ReturnRequestCommand
                                {
                                    Note = RequestReturnModel.Notes,
                                    RequestId = RequestReturnModel.RequestId,
                                    Steps = RequestReturnModel.ListReturnItem.Split(',').Select(x => int.Parse(x)).ToList()
                                });

            return new JsonResult(result);

        }

        public async Task<JsonResult> OnPostApproveRequest()
        {
                    var result = await _ProviderClient.ApproveRequestAsync(
                    new ApproveRequestCommand
                    {
                        RequestId = RequestApprovalModel.Id,
                        Notes = RequestApprovalModel.ApprovalNotes?.Trim()
                    });

            return new JsonResult(result);
        }
    }
}
