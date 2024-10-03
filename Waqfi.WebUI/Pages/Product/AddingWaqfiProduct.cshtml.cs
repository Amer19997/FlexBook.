using AutoMapper;
using DocumentFormat.OpenXml.EMMA;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.IntegrationServices;
using WebUI.Models.Product;

namespace WebUI.Pages.Product
{
    [Authorize(Roles = SystemRoles.ViewAwqafProductRequests + " , " + SystemRoles.SuperAdmin)]
    public class AddingWaqfiProductModel : PageModel
    {
        public string Error { get; set; }
        public IMapper _mapper { get; set; }
        public ILookUpClient _lookUpClient { get; set; }
        public IProductClient _productClient { get; set; }
        public IProductUnitClient _productUnitClient { get; set; }
        public IAwqafProductClient _awqafClient { get; set; }
        [BindProperty]
        public AwqafProductDto AwqafProduct { get; set; }
       
        public WagfiProductDetaliesQueryResult RequestDetails { get; set; }
        public List<GetAllMasaratItemQueryResult> masaratList { get; set; }
        public List<GetAllProduectUnitsQueryResult> Units { get; set; }

        public List<GetMasaratFilesResult> masaratFile;
        public AddingWaqfiProductModel(ILookUpClient lookUpClient, IProductClient productClient, IProductUnitClient productUnitClient, IAwqafProductClient awqafProductClient, IMapper mapper)
        {
            _lookUpClient = lookUpClient;
            _productClient = productClient;
            _awqafClient = awqafProductClient;
            _productUnitClient = productUnitClient;
            masaratFile = new List<GetMasaratFilesResult>();
            masaratList = new List<GetAllMasaratItemQueryResult>();
            Units = new List<GetAllProduectUnitsQueryResult>();
            AwqafProduct = new AwqafProductDto();
            RequestDetails = new WagfiProductDetaliesQueryResult();
            _mapper = mapper;
        }
        public async Task OnGet(Guid? requestId)
        {
            //requestId = Guid.Parse("1d259930-6b77-448f-85aa-00878d6215e9");
            masaratList = (await _lookUpClient.GetAllMasaratAsync()).Result.ToList();
            Units = (await _productUnitClient.GetAllAsync()).Result.ToList();
            RequestDetails = (await _awqafClient.GetRequestDetailesAsync(requestId)).Result;
            AwqafProduct = _mapper.Map<AwqafProductDto>(RequestDetails);
        }


        public async Task<JsonResult> OnPostAdd()
        {
            if (AwqafProduct.MasarFileId == null || AwqafProduct.MasarFileId==Guid.Empty)
             return   new JsonResult( new TResponse() { Errors = new List<string> { "يجب اختيار صوره المنتج" } });

            if (AwqafProduct.DonationMethod == 1  && (AwqafProduct.UnitType==null || AwqafProduct.UnitPrice  == null || AwqafProduct.UnitCount == null))
                return new JsonResult(new TResponse() { Errors = new List<string> { "فى حالة اختيار طريقه الدفع وحدة يجب ادخال نوع وسعر الوحدة وعدد الوحدات" } });

            var command = _mapper.Map<AddWaqfiProductCommand>(AwqafProduct);
            var result = await _awqafClient.AddProductAsync(command);
            return new JsonResult(result);
        }
       
        #region helper
        public IActionResult OnGetMasaratFilesUrl(Guid masarId)
            => new OkObjectResult(_lookUpClient.MasaraFilesListAsync(masarId)?.Result);
        #endregion


    }
}
