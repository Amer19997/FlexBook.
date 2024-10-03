using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Waqfi.Domain.Entities.Lookups;
using WebUI.Client;
using WebUI.IntegrationServices;
using WebUI.Models.Product;

namespace WebUI.Pages.ApprovedProducts
{
    [Authorize(Roles = SystemRoles.ApprovedProduct + " , " + SystemRoles.SuperAdmin)]
    public class EditModel : PageModel
    {
        private readonly IProductClient _productClient;
        private readonly IMapper _mapper;
        public ILookUpClient lookUpClient { get; set; }

        [BindProperty]
        public ApprovedProductModel Product { get; set; }
        public List<GetAllRegionDropDownQueryResult> RegtionList { get; set; }
        public List<GetAllCityDropDownQueryResult> CityList { get; set; }
        public List<GetMasaratFilesResult> masaratFile;
        public List<GetAllMasaratItemQueryResult> MasaratList { get; set; }
        public List<GetAllProductCategoryQueryResult> ProductCategoryList { get; set; }
        public List<GenderItem> GenderList { get; set; }


        public EditModel(IProductClient productClient, IMapper mapper, ILookUpClient lookUpClient)
        {
            this._productClient = productClient;
            _mapper = mapper;
            this.lookUpClient = lookUpClient;
        }
        public async Task OnGetAsync(Guid id)
        {
            MasaratList = (await lookUpClient.GetAllMasaratAsync()).Result.ToList();
            GenderList = (await lookUpClient.GetServicedGenderListAsync()).Result.ToList();
            ProductCategoryList = (await _productClient.GetProductCategoryAsync()).Result.ToList();
            var result = await _productClient.GetApprovedProductByIdAsync(id);
            CityList = lookUpClient.GetCityDropDowmCmsAsync(result.Result.RegionId).Result.Result.ToList();
            masaratFile = lookUpClient.MasaraFilesListAsync(result.Result.MasarId).Result.Result.ToList();

            RegtionList = lookUpClient.GetRegionDropDowmCmsAsync().Result.Result.ToList();
            if (result.Success)
                Product = _mapper.Map<ApprovedProductModel>(result.Result);

        }
        public async Task<JsonResult> OnPostAsync()
        {
            try
            {
                var productCommand = _mapper.Map<EditApprovedProductCommand>(Product);
                productCommand = ConvertToBinary(Product, productCommand);
                var result = await _productClient.EditApprovedProductAsync(productCommand);
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<IActionResult> OnGetCityByRegionId(Guid RegionId)
        {
            CityList = lookUpClient.GetCityDropDowmCmsAsync(RegionId).Result.Result.ToList();

            var selectList = new SelectList(CityList, "Id", "NameAr");


            return new JsonResult(selectList);

        }

        public IActionResult OnGetMasaratFilesUrl(Guid masarId)
            => new OkObjectResult(lookUpClient.MasaraFilesListAsync(masarId)?.Result);


        private EditApprovedProductCommand ConvertToBinary(ApprovedProductModel model, EditApprovedProductCommand command)
        {

            command.MobileImage = new ProductImageModel();
            command.DesktopImage = new ProductImageModel();

            if (model.MobileImage != default)
            {
                using (var ms = new MemoryStream())
                {
                    model.MobileImage.CopyTo(ms);
                    command.MobileImage.Data = ms.ToArray();

                }
                command.MobileImage.Name = model.MobileImage.FileName;
                command.MobileImage.Extension = model.MobileImage?.FileName?.Split('.')?.LastOrDefault().ToUpper();
                command.MobileImage.Size = model.MobileImage.Length;
                command.MobileImage.ContentType = model.MobileImage.ContentType;
                model.MobileImageIsEdit = true;

            }


            if (model.DesktopImage != default)
            {
                using (var ms = new MemoryStream())
                {
                    model.DesktopImage.CopyTo(ms);
                    command.DesktopImage.Data = ms.ToArray();

                }
                command.DesktopImage.Name = model.DesktopImage.FileName;
                command.DesktopImage.Extension = model.DesktopImage?.FileName?.Split('.')?.LastOrDefault().ToUpper();
                command.DesktopImage.Size = model.DesktopImage.Length;
                command.DesktopImage.ContentType = model.DesktopImage.ContentType;
                model.DesktopImageIsEdit = true;

            }




            return command;
        }

    }
}
