using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.IntegrationServices;
using WebUI.Models.Provider;

namespace WebUI.Pages.Provider
{
    [Authorize(Roles = SystemRoles.ViewProvidersRequestsList + " , " + SystemRoles.SuperAdmin)]
    public class AssocationModel : PageModel
    {

        public IAssociationsClient _associationsClient { get; set; }
        public IProviderClient _ProviderClient { get; set; }
        public GetAssociationDetailsQueryResult AssociationDetails { get; set; }
        public ISocietyClient _societyClient { get; set; }
        public string Error { get; set; }
        [BindProperty]
        public RequestApprovalModel RequestApprovalModel { get; set; }
        [BindProperty]
        public RequestRejectionModel RequestRejectionModel { get; set; }

        [BindProperty]
        public RequestReturnModel RequestReturnModel { get; set; }
        public AssocationModel(IAssociationsClient associationsClient, IProviderClient providerClient, ISocietyClient societyClient)
        {
            _associationsClient = associationsClient;
            _ProviderClient = providerClient;
            _societyClient = societyClient;
        }
        public async Task<IActionResult> OnGet(string associationId)
        {
            var result = await _associationsClient.GetAssociationDetailsAsync(Guid.Parse(associationId));

            if (!result.Success)
            {
                Error = result.Errors.FirstOrDefault();
                return RedirectToPage("/Provider/ProvidersRequests", new { error = Error });
            }

            AssociationDetails = result.Result;
            RequestApprovalModel = new() { Id = new Guid(associationId) };
            RequestRejectionModel = new() { RequestId = new Guid(associationId) };
            RequestReturnModel = new() { RequestId = new Guid(associationId) };
            RequestReturnModel.Steps = (await _associationsClient.GetAssociationStepsAsync()).Result.ToList();

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

        public async Task<JsonResult> OnPostRejectRequest()
        {
            var result = await _ProviderClient.RejectRequestAsync(new RejectRequestCommand()
            {
                Note = RequestRejectionModel.Notes,
                RequestId = RequestRejectionModel.RequestId
            });

            return new JsonResult(result);
        }
        public async Task<JsonResult> OnPostReturnRequest()
        {

            var result = await _ProviderClient.ReturnRequestAsync(new ReturnRequestCommand()
            {
                Note = RequestReturnModel.Notes,
                RequestId = RequestReturnModel.RequestId,
                Steps =  RequestReturnModel.ListReturnItem.Split(',').Select(x => int.Parse(x)).ToList()
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
