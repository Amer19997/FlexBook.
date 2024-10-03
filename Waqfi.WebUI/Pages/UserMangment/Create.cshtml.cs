using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.IntegrationServices;
using WebUI.ViewModel;

namespace WebUI.Pages.UserMangment
{
    [Authorize(Roles = SystemRoles.ViewUserList + " , " + SystemRoles.SuperAdmin)]
    public class CreateModel : PageModel
    {
        private readonly IUsersClient _User;
        private readonly IRolesClient _Role;
        public CreateModel(IUsersClient User, IRolesClient _Role) 
        {
            this._User = User;
            this._Role = _Role;
        }
        public void OnGet()
        {
        }
        public async Task<JsonResult> OnPostCreateUser(string UserName, string Email, string Phone, Guid [] Roles)
        {
            ICollection<Guid> ConvertRole = Roles;

            var CreateUser = await _User.CreateUserAsync(UserName, "+966", Phone, Email, UserStatus._2, ConvertRole);

            var Result = new
            {
                Success = CreateUser.Success,
                Message = CreateUser.Errors?.FirstOrDefault()?.ToString() ?? ""

            };
            return new JsonResult(Result);
        }

        public async Task<JsonResult> OnPostGetRolesAsync()
        {

            var GetRoles = await _Role.GetRolesAysncAsync();

            List<RolesDto> Result= GetRoles.Select(a=> new RolesDto() { 
            
                Id= a.Id,
                DescriptionAr= a.DescriptionAr,
                DescriptionEn= a.DescriptionEn,
                IsAcive = a.IsAcive,


            }).ToList();

            return new JsonResult(Result);
        }
    }
}
