using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.IntegrationServices;
using WebUI.Models.Banner;
using WebUI.Models.TopGivers;

namespace WebUI.Pages.Banner
{
    [Authorize(Roles = SystemRoles.Banner + " , " + SystemRoles.SuperAdmin)]

    public class CreateBannerModel : PageModel
    {
        public class FileDto
        {
            public string Name { get; set; }
            public double Size { get; set; }
            public string Extension { get; set; }
            public string ContentType { get; set; }
            public byte[] Data { get; set; }
        }

        

        private readonly IBannerClient _bannerClient;
        public readonly ILookUpClient _lookUpClient;
        public IProductClient _productClient { get; set; }



        public FileDto ImageFile { get; private set; }
        public FileDto ImagePhoneFile { get; private set; }


        [BindProperty]
        public BannerEditDto BannerModel { get; set; }

        public List<GetProductQueryResult> ProductBanner { get; set; }

        public List<BannerSatusDTO> LookUps { get; set; }

        public CreateBannerModel(IBannerClient bannerClient, ILookUpClient lookUpClient, IProductClient productClient)
        {
            this._bannerClient = bannerClient;
            _lookUpClient = lookUpClient;
            _productClient = productClient;
        }
        public async Task<IActionResult> OnGet() 
        {
            var LookUp = await _lookUpClient.GetBannerLookUpAsync();
            LookUps = LookUp.Result.BannerStatus.ToList();
            this.ProductBanner=(await _bannerClient.GetProductToshowInBannerAsync()).Result.ToList();

            return Page();
        }

        [HttpGet]
        public async Task<IActionResult> OnGetProductBannerDetalies( string BannerId)
        {
            var file = await _bannerClient.GetProductBannerDetailsCmsAsync(Guid.Parse(BannerId));
            return new JsonResult(file);

        }

        public async Task<JsonResult> OnPostCreateBanner()
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


            ConvertToBinaryMainImage(BannerModel);
            ConvertToBinaryMainMobilImage(BannerModel);

            CreateBannerCommand BannerEdit = new CreateBannerCommand()
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
                MobilBanner=new MobilBannerImage()
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
               ProductId=BannerModel.ProductId

            };

            var result = await _bannerClient.CreateBannersCMSAsync(BannerEdit);

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
            List<string> CheckImageLenght = new List<string> { "JPG", "PNG", "JPEG", "BMP"};

            if (CheckImageLenght.Contains(model.ImageDto?.FileName?.Split('.').LastOrDefault().ToUpper()) &&  model.ImageDto?.Length > 2097152)
                return new TResponse() { Errors = new List<string> { "الحد الاقصى لحجم صورة البانر  لا يزيد عن / 2 ميجا بايت" } };


            List<string> CheckVideoLenght = new List<string> { "AVI", "MP4" };

            if (CheckVideoLenght.Contains(model.ImageDto?.FileName?.Split('.').LastOrDefault().ToUpper()) && model.ImageDto?.Length > 5242880)
                return new TResponse() { Errors = new List<string> { "الحد الاقصى لحجم لفيديو البانر  لا يزيد عن / 5 ميجا بايت" } };


            else
                return null;
        }
        private TResponse CheckImageExtention(BannerEditDto model)
        {
            if (model.ImageDto == null && model.ProductId == Guid.Empty)
                return new TResponse() { Errors = new List<string> { "حقل صوره البانر اجبارى" } };

            List<string> listOfAllowedExtenstions = new List<string> { "JPG", "PNG", "JPEG",  "BMP", "AVI", "MP4" };

            if ((model.ImageDto != null) && !listOfAllowedExtenstions.Contains(model.ImageDto?.FileName?.Split('.').LastOrDefault().ToUpper()))
                return new TResponse() { Errors = new List<string> { "JPG, PNG, JPEG, BMP,mp4,avi نوع الملفات المسموح بها" } };

            return null;
        }

        private FileDto ConvertToBinaryMainImage(BannerEditDto model)
        {

            ImageFile = new FileDto();


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

        private FileDto ConvertToBinaryMainMobilImage(BannerEditDto model)
        {

            ImagePhoneFile = new FileDto();


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
                model.IconIsEdit = true;

            }

            return ImagePhoneFile;
        }

    }
}
