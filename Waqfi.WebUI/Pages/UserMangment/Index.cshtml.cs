using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.IntegrationServices;
using WebUI.ViewModel;

namespace WebUI.Pages.UserMangment
{
    [Authorize(Roles = SystemRoles.ViewUserList + " , " + SystemRoles.SuperAdmin)]
    public class IndexModel : PageModel
    {
        private readonly IUsersClient _User;
        private readonly IRolesClient _Role;
        private readonly UserActionInfoService _userActionInfoService;

        public IndexModel(IUsersClient User, IRolesClient role, UserActionInfoService userActionInfoService)
        {
            this._User = User;
            _Role = role;
            _userActionInfoService = userActionInfoService;
        }
        public async Task<IActionResult> OnGet()
        {
            //string url = "/.auth/login/aad?post_login_redirect_url="+ Request.Query["redirect_url"];

            var Result =await  _User.CheckUserExistAsync(new CheckAdminUserExistQuery());
            if (!Result.Success)
            {
                string url = "/UserMangment/NoUser";
                return Redirect(url);
            }

            return Page();
        }

        public async Task<JsonResult> OnPostGetAjaxAsync(string? User, string? Email, string? Phone, Guid[] Roles, int? Status)
        {

            IEnumerable<Guid> ConvertRole = Roles;

            //DateTimeFormatInfo DTFormat = new CultureInfo("ar-sa", false).DateTimeFormat;
            //DTFormat.Calendar = new HijriCalendar();

            var PageNumber = Request.Form["draw"].FirstOrDefault() ?? "1";
            int convertNumb = int.Parse(PageNumber);
            int skip = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");

            var GetDate = await _User.GetAllAdminUsersAsync(User,Phone, Email, Status, ConvertRole, skip,0);


           var data = GetDate.Select(a => new UserListApi()
            {
                Id = a.Id,
                Name = a.Name,
                CountryCode = a.CountryCode,
                MobileNumber = a.MobileNumber,
                Email = a.Email,
                RegisterAt = a.RegisterAt.ToString(" dd MMMM yyyy", new CultureInfo("ar-AE")),
                Status = ((int)a.Status),
                Roles = string.Join(",", a.Roles.Select(a => a.Name.DescriptionAr)),
                PageNumber = skip,
                Created=a.Created
            }).OrderByDescending(d => d.Created).ToList();


            int totalRecord = GetDate?.FirstOrDefault()?.TotalcCount ?? 0;
            int totalRecordFilter = GetDate?.FirstOrDefault()?.TotalCountFilter ?? 0;

            int filterRecord = data.Count();

            var returnObj = new
            {
                RowNumber= skip,
                draw = convertNumb,
                recordsTotal = totalRecord,
                recordsFiltered = totalRecordFilter,
                data = data
            };

            return new JsonResult(returnObj);
        }
        public async Task<JsonResult> OnPostDeacvtiveAsync(Guid UserId)
        {
          var Result=await  _User.DeactiveUserAsync(UserId);
            if (Result.Success)
                await _userActionInfoService.DeactivateUser(UserId.ToString());

            return new JsonResult(Result);
        }
        public async Task<JsonResult> OnPostAcvtiveAsync(Guid UserId)
        {
            var GetResult =await _User.ActiveUserAsync(UserId);

            return new JsonResult(GetResult);
        }

        public async Task<JsonResult> OnPostRedirectPageAsync()
        {
            var Result = await _User.CheckUserExistAsync(new CheckAdminUserExistQuery());
            return new JsonResult(Result);

        }

        public async Task<JsonResult> OnPostGetRolesAsync()
        {

            var GetRoles = await _Role.GetRolesAysncAsync();

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
