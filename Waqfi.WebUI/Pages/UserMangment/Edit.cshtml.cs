using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.IntegrationServices;
using WebUI.ViewModel;

namespace WebUI.Pages.UserMangment
{
    [Authorize(Roles = SystemRoles.ViewUserList + " , " + SystemRoles.SuperAdmin)]
    public class EditModel : PageModel
    {

        [BindProperty]
       public UserListApi UserModel { get; set; }

        private readonly IUsersClient _User;
        private readonly IRolesClient _Role;
        private readonly UserActionInfoService _userActionInfoService;

        public EditModel(IUsersClient User, IRolesClient role ,UserActionInfoService userActionInfoService)
        {
            this._User = User;
            _Role = role;
            _userActionInfoService = userActionInfoService;
        }
        public async Task<IActionResult> OnGetAsync(Guid UserId)
        {
            UserModel =  await GetUserAsync(UserId);

            return Page();
        }



        public async Task<UserListApi> GetUserAsync(Guid UserId)
        {
            var GetUserDetail = await _User.GetUserByIdAysncAsync(UserId);

            UserListApi CustUser = new UserListApi()
            {
                Id= UserId, 
                Name= GetUserDetail.Name,
                MobileNumber= GetUserDetail.MobileNumber,   
                Email= GetUserDetail.Email, 
                RolesString=GetUserDetail.RolesString
                
            };

            return CustUser;
        }

        public async Task<JsonResult> OnPostEditUserAsync(Guid UserId,string UserName, string Email, string Phone, Guid[] Roles)
        {

            ICollection<Guid> ConvertRole = Roles;
            var GetRoles = await _Role.GetRolesAysncAsync();
            var CreateUser =await _User.EditUserAsync(UserId, UserName, "+966", Phone, Email, UserStatus._2, ConvertRole);
            var Result = new
            {
                Success = CreateUser.Success,
                Message = CreateUser.Errors?.FirstOrDefault()?.ToString() ?? ""

            };
            if (Result.Success)
                await _userActionInfoService.UpdateUserRoles(UserId.ToString(), GetRoles.Where(x=>Roles.Contains(x.Id)).Select(x=>x.DescriptionEn).ToList());

            return new JsonResult(Result);
        }

        public async Task<JsonResult> OnPostGetRoles()
        {
            
            var GetRoles =await _Role.GetRolesAysncAsync();

            List<RolesDto> Result = GetRoles.Select(a => new RolesDto()
            {

                Id = a.Id,
                DescriptionAr = a.DescriptionAr,
                DescriptionEn = a.DescriptionEn,
                IsAcive = a.IsAcive,


            }).ToList();

            return new JsonResult(Result);
        }

    }
}
