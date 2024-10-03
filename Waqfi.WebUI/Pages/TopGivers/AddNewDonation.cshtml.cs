using AutoMapper;
using DocumentFormat.OpenXml.EMMA;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebUI.Client;
using WebUI.Enums;
using WebUI.IntegrationServices;
using WebUI.Models.Banner;
using WebUI.Models.Product;
using WebUI.Models.TopGivers;

namespace WebUI.Pages.TopGivers
{
    [Authorize(Roles = SystemRoles.TopGiverDonationViewList + " , " + SystemRoles.SuperAdmin)]
    public class AddNewDonationTopGiverModel : PageModel
    {
        public IMapper _mapper { get; set; }
        public ILookUpClient _lookUpClient { get; set; }
        public ITopGiversClient _topGiversClient { get; set; }
        public List<ProductsDto> productList { get; set; }
        public List<GetAllMasaratItemQueryResult> MasartList { get; set; }
        [BindProperty]
        public TopGiversAddDto TopGiverModel { get; set; }

        public AddNewDonationTopGiverModel(ILookUpClient lookUpClient, ITopGiversClient topGiversClient, IMapper mapper)
        {
            _lookUpClient = lookUpClient;
            _topGiversClient = topGiversClient;
            _mapper = mapper;
            productList = new List<ProductsDto>();
        }
        public async Task<IActionResult> OnGet()
        {
            var Products = await _lookUpClient.GetOfflineInProgressProductDonatorsLookupsAsync();
            var Masart=await _lookUpClient.GetAllMasaratAsync();
            productList = Products.Result.Products.ToList();
            MasartList=Masart.Result.ToList();


            return Page();
        }

        public async Task<JsonResult> OnPostAsync()
        {
            var resultCheckExtenstion = CheckImageExtention(TopGiverModel);
            if (resultCheckExtenstion != null)
                return new JsonResult(resultCheckExtenstion);

            var resultCheckLength = CheckImageLength(TopGiverModel);
            if (resultCheckLength != null)
                return new JsonResult(resultCheckLength);


            var topGiversDonationCommand = _mapper.Map<AddTopGiversDonationCommand>(TopGiverModel);
            topGiversDonationCommand = ConvertToBinary(TopGiverModel, topGiversDonationCommand);
            var result = await _topGiversClient.AddTopGiversDonationAsync(topGiversDonationCommand);

            return new JsonResult(result); 
        }

        private TResponse CheckImageLength(TopGiversAddDto model)
        {
            if (model.ImageDto.Length > 2097152)
                return new TResponse() { Errors = new List<string> { "الحد الاقصى لحجم الملف لا يزيد عن / 2 ميجا بايت" } };
            else
                return null;
        }

        private TResponse CheckImageExtention(TopGiversAddDto model)
        {
            if (model.ImageDto == null)
                return new TResponse() { Errors = new List<string> { "حقل وثيقة التبرع اجبارى" } };

            List<string> listOfAllowedExtenstions = new List<string> { "JPG", "PNG", "JPEG","BMP", "PDF" };

            if (!listOfAllowedExtenstions.Contains((model.ImageDto?.FileName?.Split('.').LastOrDefault().ToUpper())))
                return new TResponse() { Errors = new List<string> { "JPG, PNG, JPEG, BMP, PDF نوع الملفات المسموح بها" } };

            return null;
        }

        private AddTopGiversDonationCommand ConvertToBinary(TopGiversAddDto model, AddTopGiversDonationCommand command)
        {

            command.DonationDocument = new DonationDocumentDto();

            using (var ms = new MemoryStream())
            {
                model.ImageDto.CopyTo(ms);
                command.DonationDocument.Data = ms.ToArray();

            }
            command.DonationDocument.Name = model.ImageDto.FileName;
            command.DonationDocument.Extension = model.ImageDto?.FileName?.Split('.')?.LastOrDefault().ToUpper();
            command.DonationDocument.Size = model.ImageDto.Length;
            command.DonationDocument.ContentType = model.ImageDto.ContentType;

           
            return command;
        }
    }
}
