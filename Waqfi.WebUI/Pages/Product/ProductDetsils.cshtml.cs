using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.IntegrationServices;
using WebUI.Models.Product;
using Microsoft.AspNetCore.Authorization;
using DocumentFormat.OpenXml.EMMA;
using Microsoft.Extensions.Configuration;

namespace WebUI.Pages.Product
{
    [Authorize(Roles = SystemRoles.RequestProducts + " , " + SystemRoles.SuperAdmin)]
    public class ProductDetsilsModel : PageModel
    {
        private readonly IConfiguration _configuration;
        public double _maxSizeBidFileForProduct;
        public IProductClient _productClient { get; set; }

        public string Error { get; set; }

        [BindProperty]
        public ProductRequestApprovalModel RequestApprovalModel { get; set; }
        [BindProperty]
        public ProductRequestRejectionModel RequestRejectionModel { get; set; }
        [BindProperty]
        public ProductRequestReturnModel RequestReturnModel { get; set; }
        [BindProperty]
        public GetProductDetailsQueryResult ProductDetailsResult { get; set; }
        public readonly ILookUpClient _lookUpClient;

        public ProductDetsilsModel(ILookUpClient lookUpClient, IProductClient productClient, IConfiguration configuration)
        {
            this._lookUpClient = lookUpClient;
            _productClient = productClient;
            ProductDetailsResult = new GetProductDetailsQueryResult() { MainInforamtion = new MainInforamtion() };
            _configuration= configuration;
            _maxSizeBidFileForProduct = _configuration.GetSection("AppSettings").GetValue<double>("MaxSizeBidFileForProduct");
        }
        public async Task<IActionResult> OnGet(Guid requestId)
        {
            var result = await _productClient.GetProductDetailsCMSAsync(requestId);

            if (!result.Success)
            {
                Error = result.Errors.FirstOrDefault();
                return RedirectToPage("/ProductsRequest/index", new { error = Error });
            }

            ProductDetailsResult = result.Result;
            RequestApprovalModel = new() { Id = requestId,IsParallelProduct=false,ProductType=result.Result.MainInforamtion.ProductTypeId };
            RequestRejectionModel = new() { RequestId = requestId.ToString() };
            RequestReturnModel = new() { RequestId = requestId.ToString() };


            return Page();
        }

        [HttpGet]
        public async Task<IActionResult> OnGetDownloadFile(string productId, string fileId)
        {

            var file = await _productClient.GetProductFileByIdCMSAsync(Guid.Parse(productId), Guid.Parse(fileId));
            return new OkObjectResult(file);

        }
        [HttpGet]
        public async Task<IActionResult> OnGetDownloadImage(string productId, string fileId)
        {

            var file = await _productClient.GetProductImageByIdAsync(Guid.Parse(productId), Guid.Parse(fileId));
            return new OkObjectResult(file);
        }
        public async Task<JsonResult> OnPostRejectRequest()
        {
            var convertRequestId = Guid.Parse(RequestRejectionModel.RequestId.Replace("'", ""));

            var result = await _productClient.RejectProductRequestAsync(new RejectProductRequestCommand()
            {
                Notes = RequestRejectionModel.Notes?.Trim(),
                RequestId = convertRequestId
            });

            return new JsonResult(result);
        }
        public async Task<JsonResult> OnPostReturnRequest()
        {


            var convertRequestId = Guid.Parse(RequestReturnModel.RequestId.Replace("'", ""));

            var result = await _productClient.ReturnProductRequestAsync(new ReturnProductRequestCommand()
            {
                Notes = RequestReturnModel.Notes?.Trim(),
                RequestId = convertRequestId


                //Steps = RequestReturnModel.ListReturnItem.Split(',').Select(x => int.Parse(x)).ToList()
            });
            return new JsonResult(result);

        }


        public async Task<JsonResult> OnPostApproveRequest()
        {
            var command = new ApproveProductRequestCommand
            {
                RequestId = RequestApprovalModel.Id,
                Notes = RequestApprovalModel.ApprovalNotes?.Trim(),
                Percentage = RequestApprovalModel.Percentage,
                AppearOnBanner = RequestApprovalModel.ApperOnBanar,
                ParallelProduct=RequestApprovalModel.IsParallelProduct
            };

            if (RequestApprovalModel.Percentage > 0)
            {
                var checkFileResult = CheckFileValidation(RequestApprovalModel.AttachedFile);

                if (!checkFileResult.Item1)
                    return new JsonResult(new TResponse() { Errors = new List<string> { checkFileResult.Item2 } });

                command = ConvertToBinary(RequestApprovalModel.AttachedFile, command);
            }

            var result = await _productClient.ApproveProductRequestAsync(command);
            return new JsonResult(result);

        }

        #region private
        private (bool, string) CheckFileValidation(IFormFile attachedFile)
        {
            if (attachedFile == null)
                return (false, "يجب إدخال مرفق العطاء");

            var checkFileLengthAndExtentionResult = CheckFileLengthAndExtention(attachedFile);
            if (!string.IsNullOrEmpty(checkFileLengthAndExtentionResult))
                return (false, checkFileLengthAndExtentionResult);

            else
                return (true, string.Empty);

        }
        private string CheckFileLengthAndExtention(IFormFile file)
        {
            var extention = file.FileName?.Split('.')?.LastOrDefault().ToUpper();

            if (file.Length > (_maxSizeBidFileForProduct * 1048576))
                return "الحد الاقصى لحجم الملف لا يزيد عن / "+ _maxSizeBidFileForProduct + " ميجا بايت";

           else if (extention != "PDF" && extention != "JPG")
                return "مسموح فقط بملفات من نوع pdf , jpg";
            else
                return string.Empty;
        }
        private ApproveProductRequestCommand ConvertToBinary(IFormFile file, ApproveProductRequestCommand command)
        {
            command.AttachedFile = new FileData();

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                command.AttachedFile.Data = ms.ToArray();

            }
            command.AttachedFile.Name = file.FileName;
            command.AttachedFile.Extension = file.FileName?.Split('.')?.LastOrDefault().ToUpper();
            command.AttachedFile.Size = double.Parse(file.Length.ToString());
            command.AttachedFile.ContentType = file.ContentType;
            return command;
        }
        #endregion

    }
}
