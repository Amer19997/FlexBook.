using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebUI.Pages.Admin
{
    public class ForgetPasswordModel : PageModel
    {
        private readonly IAuthClient _authClient;
        [BindProperty]
        public string email { get; set; }
        public ForgetPasswordModel(IAuthClient authClient)
        {
            _authClient = authClient;
        }
    
        public void OnGet()
        {
        }
        public async Task<JsonResult> OnPostForgetPassword(string email)
        {
            var result = await _authClient.ForgetPasswordAsync(new ForgetPasswordAdminCommand { Email = email });
            return new JsonResult(result);
        }
        public async Task<IActionResult> OnPost()
        {
            var result = await _authClient.ForgetPasswordAsync(new ForgetPasswordAdminCommand { Email = email });
            return Page();

        }


    }
}
