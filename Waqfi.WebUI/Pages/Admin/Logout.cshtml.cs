using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.Admin
{
    public class LogoutModel : PageModel
    {
        public async Task<ActionResult> OnGet()
        {
            if (User?.Identity?.Name != null)
                await HttpContext.SignOutAsync("AuthCooKie");
            return RedirectToPage("/Admin/Login");

        }
    }
}
