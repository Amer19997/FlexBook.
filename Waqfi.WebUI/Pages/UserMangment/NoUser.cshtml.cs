using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.IntegrationServices;

namespace WebUI.Pages.UserMangment
{
    [Authorize(Roles = SystemRoles.ViewUserList + " , " + SystemRoles.SuperAdmin)]
    public class NoUserModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
