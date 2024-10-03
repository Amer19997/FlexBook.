using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.IntegrationServices;
using WebUI.Models.Provider;

namespace WebUI.Pages.ApprovedProvider
{
    [Authorize(Roles = SystemRoles.ViewProvidersApprovalList + " , " + SystemRoles.SuperAdmin)]
    public class SocietyDetailsModel : PageModel
    {
        public ISocietyClient _societyClient { get; set; }
        public IAssociationsClient _associationsClient { get; set; }
        public IProviderClient _ProviderClient { get; set; }
        public SocietyDetailsQueryResult SocietyDetails { get; set; }
        public string Error { get; set; }
        public string SocietyId { get; set; }
        public List<StepDto> Steps { get; set; }
        [BindProperty]
        public RequestApprovalModel RequestApprovalModel { get; set; }

        public SocietyDetailsModel(ISocietyClient societyClient, IProviderClient providerClient, IAssociationsClient associationsClient)
        {
            _societyClient = societyClient;
            _ProviderClient = providerClient;
            Steps = new List<StepDto>();
            _associationsClient = associationsClient;
        }
        public async Task<IActionResult> OnGet(string socityId)
        {
            SocietyId = socityId;
            Steps = (await _societyClient.GetSocietyStepsAsync()).Result.ToList();

            var result = await _societyClient.GetAllSocietyDetailsAsync(Guid.Parse(socityId));

            if (!result.Success)
            {
                Error = result.Errors.FirstOrDefault();
                return RedirectToPage("/ApprovedProvider/index", new { error = Error });
            }

            SocietyDetails = result.Result;
            RequestApprovalModel = new() { Id = new Guid(socityId) };
            return Page();
        }

        [HttpGet]
        public async Task<IActionResult> OnGetDownloadFile(string id, string requestId)
        {
            var file = await _societyClient.FileArrayByIdAsync(
                       Guid.Parse(requestId),
                       Guid.Parse(id)
                       );

            return new OkObjectResult(file);

        }

        public async Task<JsonResult> OnGetRejectRequest(string reason, string id)
        {
            var result = await _ProviderClient.RejectRequestAsync(
                                new RejectRequestCommand
                                {
                                    Note = reason,
                                    RequestId = Guid.Parse(id)
                                });

            return new JsonResult(result);
        }
        public async Task<JsonResult> OnGetReturnRequest(string reason, string id, int[] steps)
        {
            var result = await _ProviderClient.ReturnRequestAsync(
                                new ReturnRequestCommand
                                {
                                    Note = reason,
                                    RequestId = Guid.Parse(id),
                                    Steps = steps
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
