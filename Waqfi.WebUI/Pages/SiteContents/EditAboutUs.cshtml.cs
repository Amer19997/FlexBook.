using System.Data;
using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.IntegrationServices;
using WebUI.Models.AboutUs;
using static WebUI.ViewModel.UserResultApi;

namespace WebUI.Pages.SiteContents
{

    [Authorize(Roles = SystemRoles.SiteContent + " , " + SystemRoles.SuperAdmin)]
    public class EditAboutUsModel : PageModel
    {
        private readonly ISiteContentClient _siteContentClient;
       
        [BindProperty]
        public GetAllAboutUsQueryResult AboutUs { get; set; }
        public IMapper _mapper { get; set; }
        [BindProperty]
        public SiteContentDto SiteContentModel { get; set; }
        public EditAboutUsModel(ISiteContentClient siteContentClient, IMapper mapper)
        {
            _siteContentClient = siteContentClient;
            _mapper = mapper;

        }
        public async Task OnGet()
        {
            var result = (await _siteContentClient.GetAllSiteContentAsync());
            SiteContentModel = _mapper.Map<SiteContentDto>(result.Result);
          
            
        }
        public async Task<JsonResult> OnPostAsync()
        {
            var resultCheckExtenstion = CheckImageExtention(SiteContentModel);

            if (resultCheckExtenstion != null)
                return new JsonResult(resultCheckExtenstion);

            var resultCheckLength = CheckImageLength(SiteContentModel);

            if (resultCheckLength != null)
                return new JsonResult(resultCheckLength);

            var siteContentCommand = _mapper.Map<EditAboutUsCommand>(SiteContentModel);

            siteContentCommand = ConvertToBinary(SiteContentModel, siteContentCommand);

            var result = await _siteContentClient.EditAboutUsAsync(siteContentCommand);

            return new JsonResult(result);
        }
        private TResponse CheckImageLength(SiteContentDto model)
        {
            if (model.ImageDto?.Length > 16000000)
                return new TResponse() { Errors = new List<string> { "الحد الاقصى لحجم صورة لا يزيد عن / 2 ميجا بايت" } };

            else
                return null;
        }
        private TResponse CheckImageExtention(SiteContentDto model)
        {
            if (model.ImageDto == null)
                return new TResponse() { Errors = new List<string> { "حقل الصوره اجبارى" } };
            

            List<string> listOfAllowedExtenstions = new List<string> { "JPG", "PNG", "JPEG", "GIF", "BMP" };

            if (
                ((model.ImageDto != null) && !listOfAllowedExtenstions.Contains((model.ImageDto?.FileName?.Split('.').LastOrDefault().ToUpper()))))
                return new TResponse() { Errors = new List<string> { "JPG, PNG, JPEG, GIF, BMP نوع الملفات المسموح بها" } };

            return null;
        }
        private EditAboutUsCommand ConvertToBinary(SiteContentDto model, EditAboutUsCommand command)
        {

            command.Image= new EditFilesDto();
            

            if (model.ImageDto != default)
            {
                using (var ms = new MemoryStream())
                {
                    model.ImageDto.CopyTo(ms);
                    command.Image.Data = ms.ToArray();

                }
                command.Image.Name = model.ImageDto.FileName;
                command.Image.Extension = model.ImageDto?.FileName?.Split('.')?.LastOrDefault().ToUpper();
                command.Image.Size = model.ImageDto.Length;
                command.Image.ContentType = model.ImageDto.ContentType;
                
            }

          
            return command;
        }

    }
}
