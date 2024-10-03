using System.Formats.Asn1;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Client;
using WebUI.ViewModel;

namespace WebUI.Pages.Admin
{
   
    public class CreatePasswordModel : PageModel
    {
        [BindProperty]
        public CreatePassword PasswordModel { get; set; }

        private readonly IUsersClient _User;
        public List<string> ErrorList { get; set; }
        public bool Result { get; set; }
        private readonly IMapper _mapper;

        public CreatePasswordModel(IUsersClient User, IMapper mapper)
        {
            this._User = User;
            ErrorList= new List<string>();
            _mapper=mapper;
            Result = false;
        }

        public async Task<IActionResult> OnGet( string otp)
        {
            if(string.IsNullOrEmpty(otp))
                return RedirectToPage("/LinkExpired");

            PasswordModel = new CreatePassword() { OTP =otp};

            var checkResul = await _User.CheckOTPChangePasswordAsync(otp);

            if (!checkResul.Success)
                return RedirectToPage("/LinkExpired");

            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            var command=_mapper.Map<SetPaswordCommand>(PasswordModel); 
            var changePasswordResult= await _User.SetPasswordAsync(command);

            if (!changePasswordResult.Success)
            {
                ErrorList = changePasswordResult.Errors.ToList();
                Result = false;
                return Page();
            }
            else
            {
                Result = true;
                return Page();
            }
        }
    }
}
