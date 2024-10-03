
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Models.Question;
using WebUI.ViewModel;
using WebUI.Common;
using WebUI.IntegrationServices;

namespace WebUI.Pages.Admin
{

    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login login { get; set; }

        private readonly IAuthClient _Login;
        private readonly UserActionInfoService _userActionInfoService;

        public LoginModel(IAuthClient login, UserActionInfoService userActionInfoService)
        {
            _Login = login;
            _userActionInfoService = userActionInfoService;
        }

        public async Task OnGet()
        {
            
        }

        public async Task<IActionResult> OnPost()
        {


            if (!ModelState.IsValid || (string.IsNullOrWhiteSpace(login.Email) && string.IsNullOrWhiteSpace(login.Password)))
            {
                return Page();
            }

            var Result = await _Login.LoginAsync(login.Email, login.Password);

            if (Result.Success==true && !Result.Result.IsBlocked)
            {
                var claims = new List<Claim>()
                {
                    new Claim("Name",Result.Result.Name),
                    new Claim(ClaimTypes.Name,Result.Result.Id.ToString()),
                    new Claim("TOKEN",Result.Result.Token),
                };

                claims.AddRange(Result.Result.Roles.Select(x => new Claim(ClaimTypes.Role, x)));

                var identity = new ClaimsIdentity(claims, "AuthCooKie");

                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("AuthCooKie", claimsPrincipal);

                await _userActionInfoService.LoginUser(new UserActionInfo()
                {
                    UserId = Result.Result.Id,
                    Roles = Result.Result.Roles.ToList(),
                    IsActive = true,
                    Name = Result.Result.Name,
                    Token=Result.Result.Token
                });

                TempData["SuccesLogin"] = "";
                return RedirectToPage("/Index");

            }

            if (Result.Result !=null && Result.Result.IsBlocked)
            {
                TempData["sweet"] =  Result.Result.RemainingBlockMinutes;
                return Page();
            }
            if (!Result.Success && Result.Errors.Count() != 0)
            {
                TempData["sweet1"] = "";
                return Page();
            }


            return Page();
        }
    }
}
