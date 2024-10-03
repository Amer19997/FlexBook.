using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using WebUI.Client;
using WebUI.Models.AboutusDto;

namespace WebUI.Pages.AboutUs
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public AboutusDto AboutusDto { get; set; }
        private readonly IConfiguration _configuration;
        public IWaqfyContentClient WaqfyContentClient { get; set; }
        public IMapper _mapper { get; set; }

        public IndexModel(IWaqfyContentClient waqfyContentClient, IMapper mapper, IConfiguration configuration)
        {
            WaqfyContentClient = waqfyContentClient;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async void OnGet()
        {
            var result =  WaqfyContentClient.GetAllAsync(WaqfyContentType._1).Result.Result.ToList();

            AboutusDto = _mapper.Map<AboutusDto>(result);



        }

        public async Task<JsonResult> OnPost() 
        {
            var resultCheckExtenstion = CheckImageExtention(AboutusDto);
            if (resultCheckExtenstion != null)
                return new JsonResult(resultCheckExtenstion);

            

            var resultCheckLength = CheckImageLength(AboutusDto);

            if (resultCheckLength != null)
                return new JsonResult(resultCheckLength);

            WaqfyContentCommand waqfyContentCommand = new WaqfyContentCommand();
             var image = ConvertToBinary(AboutusDto, waqfyContentCommand);

            var list = new List<Details>()
            {
                new Details() { ContentKey="AboutUs-WagFIAr",ContentValue=AboutusDto.AboutWagfiAr},
                new Details() { ContentKey="AboutUs-WagFIEn",ContentValue=AboutusDto.AboutWagfiEn},
                new Details() { ContentKey="AboutUs-WagfiIdeaAr",ContentValue=AboutusDto.WagfiIdeaAr},
                new Details() { ContentKey="AboutUs-WagfiIdeaEn",ContentValue=AboutusDto.WagfiIdeaEn},
                new Details() { ContentKey="WagfitargetAR",ContentValue=AboutusDto.WagfitargetAR},
                new Details() { ContentKey="WagfitargetEn",ContentValue=AboutusDto.WagfitargetEN},
                new Details() { ContentKey="WagfiproductAR",ContentValue=AboutusDto.WagfiproductAR},
                new Details() { ContentKey="WagfiproductEn",ContentValue=AboutusDto.WagfiproductEN},
                new Details() { ContentKey="WagfiEffectAR",ContentValue=AboutusDto.WagfiEffectAR},
                new Details() { ContentKey="WagfiEffectEn",ContentValue=AboutusDto.WagfiEffectEN},
                
            };

            var result =await WaqfyContentClient.UpdateAsync(new WaqfyContentCommand() { ContentType = WaqfyContentType._1, Details = list , Icon= image.Icon,IconIsEdit=AboutusDto.IconIsEdit });



            return new JsonResult(result);
        }

        private TResponse CheckImageLength(AboutusDto model)
        {
            long UploadMaxSize = _configuration.GetSection("AppSettings").GetValue<int>("MasarMaxSize");
            long MasarMaxSize = _configuration.GetSection("AppSettings").GetValue<int>("MasarTotalSize");

            if (model.IconDto?.Length > 600000)
                return new TResponse() { Errors = new List<string> { "الحد الاقصى لحجم صورة لأيقونة العرض لا يزيد عن / 600 كيلو بايت" } };

            else
                return null;
        }
        private TResponse CheckImageExtention(AboutusDto model)
        {
            if (model.IconDto == null && model.IconIsEdit)
                return new TResponse() { Errors = new List<string> { "حقل صوره الوجهه اجبارى" } };

            List<string> listOfAllowedExtenstions = new List<string> { "JPG", "PNG", "JPEG", "GIF", "BMP" };
            if (model.IconDto != null)
            {
                if (!listOfAllowedExtenstions.Contains((model.IconDto?.FileName?.Split('.').LastOrDefault().ToUpper())))
                    return new TResponse() { Errors = new List<string> { "JPG, PNG, JPEG, GIF, BMP نوع الملفات المسموح بها" } };
            }
           

            return null;
        }


        private WaqfyContentCommand ConvertToBinary(AboutusDto model, WaqfyContentCommand command)
        {

            command.Icon = new EditFileDto();

            if (model.IconDto != default)
            {
                using (var ms = new MemoryStream())
                {
                    model.IconDto.CopyTo(ms);
                    command.Icon.Data = ms.ToArray();

                }
                command.Icon.Name = model.IconDto.FileName;
                command.Icon.Extension = model.IconDto?.FileName?.Split('.')?.LastOrDefault().ToUpper();
                command.Icon.Size = model.IconDto.Length;
                command.Icon.ContentType = model.IconDto.ContentType;
                model.IconIsEdit = true;

            }


           

            return command;
        }

    }
}
