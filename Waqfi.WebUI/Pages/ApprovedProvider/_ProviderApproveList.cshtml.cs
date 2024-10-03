using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.IntegrationServices;

namespace WebUI.Pages.ApprovedProvider
{
    [Authorize(Roles = SystemRoles.ViewProvidersApprovalList + " , " + SystemRoles.SuperAdmin)]
    public class _ProviderApproveListModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
