using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.IntegrationServices;
using WebUI.Models.Provider;

namespace WebUI.Pages.ApprovedProvider
{
    [Authorize(Roles = SystemRoles.ViewProvidersApprovalList + " , " + SystemRoles.SuperAdmin)]
    public class AssocationDetailsModel : PageModel
    {

        public IAssociationsClient _associationsClient { get; set; }
        public IProviderClient _ProviderClient { get; set; }
        public GetAssociationApprovalDetailsQueryResult AssociationDetails { get; set; }
        public ISocietyClient _societyClient { get; set; }
        public string Error { get; set; }

        public string AssociationId { get; set; }
        [BindProperty]
        public RequestApprovalModel RequestApprovalModel { get; set; }

        public List<StepDto> Steps { get; set; }

        public AssocationDetailsModel(IAssociationsClient associationsClient, IProviderClient providerClient, ISocietyClient societyClient)
        {
            _associationsClient = associationsClient;
            _ProviderClient = providerClient;
            Steps = new List<StepDto>();
            _societyClient = societyClient;
        }
        public async Task<IActionResult> OnGet(string associationId)
        {
            AssociationId = associationId;
            Steps = (await _associationsClient.GetAssociationStepsAsync()).Result.ToList();
            var result = await _associationsClient.GetAssociationApprovalDetailsAsync(Guid.Parse(associationId));

            if (!result.Success)
            {
                Error = result.Errors.FirstOrDefault();
                return RedirectToPage("/ApprovedProvider/index", new { error = Error });
            }

            AssociationDetails = result.Result;
            RequestApprovalModel = new() { Id = new Guid(associationId) };
            return Page();
        }

        [HttpGet]
        public async Task<IActionResult> OnGetDownloadFile(string id, string requestId)
        {
            var file = await _associationsClient.FileArrayByIdAsync(
                       Guid.Parse(requestId),
                       Guid.Parse(id)
                       );

            return new OkObjectResult(file);

        }

        public async Task<JsonResult> OnGetRejectRequest(string reason, string Id)
        {
            var result = await _ProviderClient.RejectRequestAsync(new RejectRequestCommand() { Note = reason, RequestId = Guid.Parse(Id) });
            return new JsonResult(result);
        }
        public async Task<JsonResult> OnGetReturnRequest(string reason, string Id, int[] steps)
        {
            var result = await _ProviderClient.ReturnRequestAsync(new ReturnRequestCommand() { Note = reason, RequestId = Guid.Parse(Id), Steps = steps });
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
