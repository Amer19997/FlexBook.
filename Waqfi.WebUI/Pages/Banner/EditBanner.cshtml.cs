using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.IntegrationServices;
using WebUI.Models.Banner;

namespace WebUI.Pages.Banner
{
    [Authorize(Roles = SystemRoles.Banner + " , " + SystemRoles.SuperAdmin)]

    public class EditBannerModel : PageModel
    {
        private readonly IBannerClient _BannerClient;
        public readonly ILookUpClient _lookUpClient;
        public IMapper _mapper { get; set; }

        public string Error { get; set; }
        [BindProperty]
        public bool IsProduct { get; set; }
        public string IsDeleted { get; set; }
        //public URLS URLS { get; private set; }
        public URLS URLS { get; private set; }
        public Models.Banner.FileDto ImageFile { get; private set; }
        public Models.Banner.FileDto ImagePhoneFile { get; private set; }


        [BindProperty]
        public BannerEditDto BannerModel { get; set; }
        //public GetBannerQueryResult BannerDetailsResult { get; set; }
        public List<BannerSatusDTO> LookUps { get; set; }

        public EditBannerModel(IBannerClient BannerClient, ILookUpClient lookUpClient, IMapper mapper)
        {
            this._BannerClient = BannerClient;
            this._lookUpClient = lookUpClient;
            this._mapper = mapper;

        }
        public async Task<IActionResult> OnGet(Guid BannerId)
        {
            var result = await _BannerClient.GetBannerCMSAsync(BannerId);
            var LookUp = await _lookUpClient.GetBannerLookUpAsync();

            if (!result.Success)
            {
                Error = result.Errors.FirstOrDefault();
                return RedirectToPage("/Banner/Index", new { error = Error });
            }
            IsProduct = result.Result.IsProduct;
            URLS = AssingnUrl(result.Result);
            BannerModel = _mapper.Map<BannerEditDto>(result.Result);
            LookUps = LookUp.Result.BannerStatus.ToList();
            return Page();
        }
        private URLS AssingnUrl(GetBannerQueryResult result)
        {
            var ulr = new URLS();
            if (result.Image.BannerUrl != null)
                ulr.BannerImageUrl = result.Image.BannerUrl;

            if(result.MobileImage.BannerUrl != null)
                ulr.BannerImageMobileUrl = result.MobileImage.BannerUrl;

            return ulr;

        }

        public async Task<JsonResult> OnPostEditBanner()
        {

            //if (!IsRtl(BannerModel.NameAr))
            //    return new JsonResult(new TResponse() { Errors = new List<string> { "عفوا اسم البانر بالعربية غير صحيح" } });

            //if (IsRtl(BannerModel.NameEn))
            //    return new JsonResult(new TResponse() { Errors = new List<string> { "عفوا اسم البانر بالانجليزية غير صحيح" } });


            var resultCheckDate = CheckDateLength();

            if (resultCheckDate != null)
                return new JsonResult(resultCheckDate);

            var resultCheckExtenstion = CheckImageExtention(BannerModel);

            if (resultCheckExtenstion != null)
                return new JsonResult(resultCheckExtenstion);

            var resultCheckLength = CheckImageLength(BannerModel);

            if (resultCheckLength != null)
                return new JsonResult(resultCheckLength);


            ConvertToBinary(BannerModel);
            ConvertToBinaryMainMobilImage(BannerModel);


            EditBannerCommand BannerEdit = new EditBannerCommand()
            {
                Id = BannerModel.Id,
                BannerNameAr = BannerModel.NameAr.Trim(),
                BannerNameEn = BannerModel.NameEn.Trim(),
                StartAt = BannerModel.StartAt,
                EndAt = BannerModel.EndAt,
                Url = BannerModel?.URL?.Trim() ?? "",
                Status = BannerModel.status,
                Priority = BannerModel.Periorty,
                BannerDetailsAr = BannerModel.DescriptionArbic?.Trim(),
                BannerDetailsEn = BannerModel.DescriptionEnglish?.Trim(),
                IsEditImage = BannerModel.IconIsEdit,
                IsEditImageMobile = BannerModel.IconMobileIsEdit,
                MobilBanner = new MobilBannerImage()
                {
                    Name = ImagePhoneFile.Name,
                    ContentType = ImagePhoneFile.ContentType,
                    Data = ImagePhoneFile.Data,
                    Extension = ImagePhoneFile.Extension,
                    Size = ImagePhoneFile.Size,
                },
                Name = ImageFile.Name,
                ContentType = ImageFile.ContentType,
                Data = ImageFile.Data,
                Extension = ImageFile.Extension,
                Size = ImageFile.Size,
                Isproduct= IsProduct

            };

            var result = await _BannerClient.EditBannersCMSAsync(BannerEdit);

            return new JsonResult(result);
        }



        public bool IsRtl(string input)
        {
            return Regex.IsMatch(input, @"\p{IsArabic}");
        }
        private TResponse CheckDateLength()
        {
            if (BannerModel.StartAt > BannerModel.EndAt)
                return new TResponse() { Errors = new List<string> { "يجب أن يكون تاريخ الظهور أقل من تاريخ الإخفاء" } };

            else
                return null;
        }

        private TResponse CheckImageLength(BannerEditDto model)
        {

            List<string> CheckImageLenght = new List<string> { "JPG", "PNG", "JPEG", "BMP" };

            if (CheckImageLenght.Contains(model.ImageDto?.FileName?.Split('.').LastOrDefault().ToUpper()) && model.ImageDto?.Length > 2097152)
                return new TResponse() { Errors = new List<string> { "الحد الاقصى لحجم صورة البانر  لا يزيد عن / 2 ميجا بايت" } };


            List<string> CheckVideoLenght = new List<string> { "AVI", "MP4" };

            if (CheckVideoLenght.Contains(model.ImageDto?.FileName?.Split('.').LastOrDefault().ToUpper()) && model.ImageDto?.Length > 5242880)
                return new TResponse() { Errors = new List<string> { "الحد الاقصى لحجم لفيديو البانر  لا يزيد عن / 5 ميجا بايت" } };

            if (CheckImageLenght.Contains(model.PhoneImage?.FileName?.Split('.').LastOrDefault().ToUpper()) && model.PhoneImage?.Length > 2097152)
                return new TResponse() { Errors = new List<string> { "الحد الاقصى لحجم صورة جوال البانر  لا يزيد عن / 2 ميجا بايت" } };

            if (CheckVideoLenght.Contains(model.PhoneImage?.FileName?.Split('.').LastOrDefault().ToUpper()) && model.PhoneImage?.Length > 5242880)
                return new TResponse() { Errors = new List<string> { "الحد الاقصى لحجم لفيديو جوال البانر  لا يزيد عن / 5 ميجا بايت" } };
            
           return null;
        }
        private TResponse CheckImageExtention(BannerEditDto model)
        {
            if (model.ImageDto == null && model.IconIsEdit)
                return new TResponse() { Errors = new List<string> { "حقل صوره/فيديو البانر اجبارى" } };

            List<string> listOfAllowedExtenstions = new List<string> { "JPG", "PNG", "JPEG", "BMP", "AVI", "MP4" };

            if ((model.ImageDto != null) && !listOfAllowedExtenstions.Contains(model.ImageDto?.FileName?.Split('.').LastOrDefault().ToUpper()))
                return new TResponse() { Errors = new List<string> { "JPG, PNG, JPEG, BMP,mp4,avi نوع الملفات المسموح بها" } };

            return null;
        }

        private WebUI.Models.Banner.FileDto ConvertToBinary(BannerEditDto model)
        {

             ImageFile = new WebUI.Models.Banner.FileDto();


            if (model.ImageDto != default)
            {
                using (var ms = new MemoryStream())
                {
                    model.ImageDto.CopyTo(ms);
                    ImageFile.Data = ms.ToArray();

                }
                ImageFile.Name = model.ImageDto.FileName;
                ImageFile.Extension = model.ImageDto?.FileName?.Split('.')?.LastOrDefault().ToUpper();
                ImageFile.Size = model.ImageDto.Length;
                ImageFile.ContentType = model.ImageDto.ContentType;
                model.IconIsEdit = true;

            }

            return ImageFile;
        }
        private WebUI.Models.Banner.FileDto ConvertToBinaryMainMobilImage(BannerEditDto model)
        {

            ImagePhoneFile = new WebUI.Models.Banner.FileDto();


            if (model.PhoneImage != null)
            {

                using (var ms = new MemoryStream())
                {
                    model.PhoneImage.CopyTo(ms);
                    ImagePhoneFile.Data = ms.ToArray();

                }
                ImagePhoneFile.Name = model.PhoneImage.FileName;
                ImagePhoneFile.Extension = model.PhoneImage?.FileName?.Split('.')?.LastOrDefault().ToUpper();
                ImagePhoneFile.Size = model.PhoneImage.Length;
                ImagePhoneFile.ContentType = model.PhoneImage.ContentType;
                model.IconMobileIsEdit = true;

            }

            return ImagePhoneFile;
        }

    }
}
