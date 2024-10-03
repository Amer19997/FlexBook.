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
    public class EditMasaratItemModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public ILookUpClient _lookUpClient { get; set; }
        public IMapper _mapper { get; set; }
        [BindProperty]
        public MasaratDto MasaratModel { get; set; }
        public URLS URLS { get; set; }
        public int MasaratImgMax { get; set; }
        public int MasaratImgMaxMB { get; set; }


        public EditMasaratItemModel(ILookUpClient lookUpClient, IMapper mapper, IConfiguration configuration)
        {
            _lookUpClient = lookUpClient;
            _mapper = mapper;
            URLS = new URLS();
            _configuration = configuration;
        }
        public async Task OnGet(Guid id)
        {
           
            MasaratImgMax = _configuration.GetSection("AppSettings").GetValue<int>("MasarMaxImages");
            MasaratImgMaxMB = _configuration.GetSection("AppSettings").GetValue<int>("MasarMaxSize");


            var item = (await _lookUpClient.GetMasaratItemToEditAsync(id)).Result;
            URLS = AssingnUrl(item);
            MasaratModel = _mapper.Map<MasaratDto>(item);
            MasaratModel.listSize = item.Library.Sum(_ => _.Length);
            MasaratModel.ListCount = item.Library.Count();
            


        }
        public async Task<JsonResult> OnPostEditItem()
        {
            var resultCheckExtenstion = CheckImageExtention(MasaratModel);
            if (resultCheckExtenstion != null)
                return new JsonResult(resultCheckExtenstion);

            var CheckImageCount = CheckTotalCount(MasaratModel);
            if (CheckImageCount != null)
                return new JsonResult(CheckImageCount);

            var resultCheckLength = CheckImageLength(MasaratModel);

            if (resultCheckLength != null)
                return new JsonResult(resultCheckLength);




            var masaratCommand = _mapper.Map<EditMasaratItemCommand>(MasaratModel);

            masaratCommand = ConvertToBinary(MasaratModel, masaratCommand);

            var result = await _lookUpClient.EditMasaratAsync(masaratCommand);

            return new JsonResult(result);
        }

        public async Task<JsonResult> OnGetDeleteMassarIMG(Guid id)
        {
            var GetResult = await _lookUpClient.DeleteMasaraImageAsync(id);
            var x = GetResult.Errors?.FirstOrDefault();
            return new JsonResult(new DeleteImgResult { Success = GetResult.Success, Data = x});
        }

        private TResponse CheckTotalCount(MasaratDto model)
        {
            long MaxImages = _configuration.GetSection("AppSettings").GetValue<int>("MasarMaxImages");


            if (model.OtherImageDto?.Count() + model.ListCount > MaxImages)
                return new TResponse() { Errors = new List<string> { "عفوا لا يمكن تخطي عدد الصور المسموح به في مسار واحد وهو "+MaxImages+" صورة" } };
            else
                return null;
        }

        private TResponse CheckImageLength(MasaratDto model)
        {            
            long UploadMaxSize = _configuration.GetSection("AppSettings").GetValue<int>("MasarMaxSize") ;
            long MasarMaxSize = _configuration.GetSection("AppSettings").GetValue<int>("MasarTotalSize") ;

            if (model.IconDto?.Length > 300000)
                return new TResponse() { Errors = new List<string> { "الحد الاقصى لحجم صورة لأيقونة العرض لا يزيد عن / 300 كيلو بايت" } };

            if (model.OtherImageDto?.Sum(_ => _.Length) + model.listSize > (MasarMaxSize*1024*1024))
                return new TResponse() { Errors = new List<string> { "عفوا لا يمكن تخطي مساحه الصور المسموح به في مسار واحد وهو " + MasarMaxSize + " ميجا" } };

            if (model.OtherImageDto?.Sum(_ => _.Length) >( UploadMaxSize * 1024 * 1024))
                return new TResponse() { Errors = new List<string> { "اقصي حجم مسموح به لرفع الملفات في مرة واحده هو "+UploadMaxSize+" ميجا" } };

            else
                return null;
        }
        private TResponse CheckImageExtention(MasaratDto model)
        {
            if (model.IconDto == null && model.IconIsEdit)
                return new TResponse() { Errors = new List<string> { "حقل الايقون اجبارى" } };
          
            List<string> listOfAllowedExtenstions = new List<string> { "JPG", "PNG", "JPEG", "GIF", "BMP" };
            if (model.IconDto != null)
            {
                if (!listOfAllowedExtenstions.Contains((model.IconDto?.FileName?.Split('.').LastOrDefault().ToUpper())))
                    return new TResponse() { Errors = new List<string> { "JPG, PNG, JPEG, GIF, BMP نوع الملفات المسموح بها" } };
            }
            if (model.OtherImages != null)
            {
               if(!listOfAllowedExtenstions.Any(e => model.OtherImageDto.Any(x => e == x.FileName?.Split('.').LastOrDefault().ToUpper())))
                    return new TResponse() { Errors = new List<string> { "JPG, PNG, JPEG, GIF, BMP نوع الملفات المسموح بها" } };
            }

            return null;
        }
        private EditMasaratItemCommand ConvertToBinary(MasaratDto model, EditMasaratItemCommand command)
        {

            command.Icon = new EditFileDto();
            command.OtherImages = new List<EditFileDto>();

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

            if (model.OtherImageDto != null)
            {
                foreach (var imageDto in model.OtherImageDto)
                {
                    var IMG = new EditFileDto();
                    using (var ms2 = new MemoryStream())
                    {
                        imageDto.CopyTo(ms2);
                        IMG.Data = ms2.ToArray();

                    }
                    IMG.Name = imageDto.FileName;
                    IMG.Extension = imageDto?.FileName?.Split('.')?.LastOrDefault().ToUpper();
                    IMG.Size = imageDto.Length;
                    IMG.ContentType = imageDto.ContentType;
                    command.OtherImages.Add(IMG);
                }

                model.OtherImagesIsEdit = true;
            }

            //if (model.FirstImageDto != default)
            //{
            //    using (var ms3 = new MemoryStream())
            //    {
            //        model.FirstImageDto.CopyTo(ms3);
            //        command.FirstImage.Data = ms3.ToArray();

            //    }
            //    command.FirstImage.Name = model.FirstImageDto.FileName;
            //    command.FirstImage.Extension = model.FirstImageDto?.FileName?.Split('.')?.LastOrDefault().ToUpper();
            //    command.FirstImage.Size = model.FirstImageDto.Length;
            //    command.FirstImage.ContentType = model.FirstImageDto.ContentType;
            //    model.FirstIsEdit = true;
            //}
            //if (model.SecondImageDto != default)
            //{
            //    using (var ms4 = new MemoryStream())
            //    {
            //        model.SecondImageDto.CopyTo(ms4);
            //        command.SecondImage.Data = ms4.ToArray();

            //    }
            //    command.SecondImage.Name = model.SecondImageDto.FileName;
            //    command.SecondImage.Extension = model.SecondImageDto?.FileName?.Split('.')?.LastOrDefault().ToUpper();
            //    command.SecondImage.Size = model.SecondImageDto.Length;
            //    command.SecondImage.ContentType = model.SecondImageDto.ContentType;
            //    model.SecondIsEdit = true;
            //}



            return command;
        }
        private URLS AssingnUrl(GetMasaratItemToEditQueryResult result)
        {
            var ulr = new URLS();
            if (result.Icon != null)
                ulr.IconUrl = result.Icon.IconUrl;



            ulr.LibraryUrl = result.Library.ToList();

            return ulr;

        }


    }
    public class URLS
    {
        public string IconUrl { get; set; }
        public List<LibraryDto> LibraryUrl { get; set; }
    }
    public class DeleteImgResult
    {
        public bool Success { get; set; }
        public object Data { get; set; }
    }
}
