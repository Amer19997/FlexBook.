using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.IntegrationServices;
using WebUI.Models.Masarat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace WebUI.Pages.Masarat
{
    [Authorize(Roles = SystemRoles.ViewMasaratList + " , " + SystemRoles.SuperAdmin)]
    public class AddMasaratItemModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public ILookUpClient _lookUpClient { get; set; }
        public IMapper _mapper { get; set; }
        [BindProperty]
        public MasaratDto MasaratModel { get; set; }
        public int MasaratImgMax { get; set; }
        public int MasaratImgMaxMB { get; set; }
        public AddMasaratItemModel(ILookUpClient lookUpClient, IMapper mapper, IConfiguration configuration)
        {
            _lookUpClient = lookUpClient;
            _mapper = mapper;
            _configuration = configuration;
        }
        public void OnGet()
        {
            MasaratImgMax = _configuration.GetSection("AppSettings").GetValue<int>("MasarMaxImages");
            MasaratImgMaxMB = _configuration.GetSection("AppSettings").GetValue<int>("MasarMaxSize");
        }
        public async Task<JsonResult> OnPostAddItem()
        {
            var checkResult=await  ChecksMyUploads();
            if (checkResult != null)
                return new JsonResult(checkResult);

            var masaratCommand = _mapper.Map<AddNewMasaratItemCommand>(MasaratModel);
            masaratCommand = ConvertToBinary(MasaratModel, masaratCommand);
            var result = await _lookUpClient.AddMasaratAsync(masaratCommand);

            return new JsonResult(result);
        }
        private async Task<TResponse?> ChecksMyUploads()
        {
            var resultCheckExtenstion = CheckImageExtention(MasaratModel);
            if (resultCheckExtenstion != null)
                return resultCheckExtenstion;

            var resultCheckLength = CheckImageLength(MasaratModel);
            if (resultCheckLength != null)
                return resultCheckLength;

            //var checkUploadSize = CheckTotalSize(MasaratModel);
            //if (checkUploadSize != null)
            //    return checkUploadSize;

            return null;

        }
        private TResponse CheckImageLength(MasaratDto model)
        {

            if (model.IconDto.Length > 300000)
                return new TResponse() { Errors = new List<string> { "الحد الاقصى لحجم صورة الأيقونة  لا يزيد عن / 300 كيلو بايت" } };

            else
                return null;
        }
        //private TResponse CheckTotalSize(MasaratDto model)
        //{
        //    var MB = _configuration.GetSection("AppSettings").GetValue<int>("MasarMaxSize");
        //    long UploadMaxSize = MB * 1048576;
        //    if (model.OtherImageDto.Sum(_ => _.Length)> UploadMaxSize)
        //        return new TResponse() { Errors = new List<string> { " الحد الأقصى لحجم كل الصور لا يزيد عن" + " MB " + MB } };

        //    return null;
        //}
        private TResponse CheckImageExtention(MasaratDto model)
        {
            if (model.IconDto == null)
                return new TResponse() { Errors = new List<string> { "حقل الايقون اجبارى" } };

            if (model.OtherImageDto == null || model.OtherImageDto.Count == 0)
                return new TResponse() { Errors = new List<string> { "حقل الصوره إجبارى" } };

            List<string> listOfAllowedExtenstions = new List<string> { "JPG", "PNG", "JPEG", "GIF", "BMP" };

            if (!listOfAllowedExtenstions.Contains((model.IconDto?.FileName?.Split('.').LastOrDefault().ToUpper())) ||
               (!listOfAllowedExtenstions.Any(e => model.OtherImageDto.Any(x => e == x.FileName?.Split('.').LastOrDefault().ToUpper()))))
                return new TResponse() { Errors = new List<string> { "JPG, PNG, JPEG, GIF, BMP نوع الملفات المسموح بها" } };

            return null;
        }
        private AddNewMasaratItemCommand ConvertToBinary(MasaratDto model, AddNewMasaratItemCommand command)
        {
            command.Others = new List<FileDto>();
            command.Icon = new FileDto();

            using (var ms = new MemoryStream())
            {
                model.IconDto.CopyTo(ms);
                command.Icon.Data = ms.ToArray();

            }
            command.Icon.Name = model.IconDto.FileName;
            command.Icon.Extension = model.IconDto?.FileName?.Split('.')?.LastOrDefault().ToUpper();
            command.Icon.Size =double.Parse( model.IconDto?.Length.ToString());
            command.Icon.ContentType = model.IconDto.ContentType;

            foreach (var item in model.OtherImageDto)
            {
                var itemImage = new FileDto()
                {
                    Name = item.FileName,
                    Extension = item?.FileName?.Split('.')?.LastOrDefault().ToUpper(),
                    Size = item.Length,
                    ContentType = item.ContentType,
                };
                using (var ms2 = new MemoryStream())
                {
                    item.CopyTo(ms2);
                    itemImage.Data = ms2.ToArray();

                }
                command.Others.Add(itemImage);
            }
            return command;
        }

    }
}
