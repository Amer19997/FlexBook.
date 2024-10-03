using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using WebUI.Client;
using WebUI.IntegrationServices;
using WebUI.Models.Provider;

namespace WebUI.Pages.ContactUsRequest
{
    [Authorize(Roles = SystemRoles.ContactUsList + " , " + SystemRoles.SuperAdmin)]

    public class ContactUsDetaliesModel : PageModel
    {
        public double _maxSizeBidFileForProduct;
        private readonly IConfiguration _configuration;

        private readonly IContactUsClient _contactUsClient;
        [BindProperty(SupportsGet = true)]
        public GetContactUsDetalisCmsQueryResult GetContactUs { get; set; }

        [BindProperty]

        public Models.contactusDto.ContactUsRequestReplayMessageModel RequestReplayMessageModel { get; set; }
        [BindProperty]

        public Models.contactusDto.ContactUsRequestCloseModel CloseRequestModel { get; set; }
        public ContactUsDetaliesModel(IContactUsClient contactUsClient, IConfiguration configuration)
        {
            _contactUsClient = contactUsClient;
            _configuration = configuration;

            _maxSizeBidFileForProduct = _configuration.GetSection("AppSettings").GetValue<double>("MaxSizeBidFileForContactUs");
        }

        public async Task<IActionResult> OnGet(Guid RequestId)
        {
            var ContactUs=await _contactUsClient.GetContactUsDetailsCmsAsync(RequestId);

                  
            GetContactUs = ContactUs.Result;

            RequestReplayMessageModel = new() { Id = RequestId.ToString()};
            CloseRequestModel = new() { Id = RequestId.ToString() };
            return Page();
        }

        public async Task<JsonResult> OnPostRejectRequest()
        {
            var command= new AddConatctUsReplayAdminCommand()
            {
                ReplyMessage = RequestReplayMessageModel.Message?.Trim(),
                RequestId = Guid.Parse(RequestReplayMessageModel.Id),


            };

            if (RequestReplayMessageModel?.ConatctUsFile?.Length > 0)
            {
                var checkFileResult = CheckFileValidation(RequestReplayMessageModel.ConatctUsFile);

                if (!checkFileResult.Item1)
                    return new JsonResult(new TResponse() { Errors = new List<string> { checkFileResult.Item2 } });

                command = ConvertToBinary(RequestReplayMessageModel.ConatctUsFile, command);
            }
            var result = await _contactUsClient.AddReplayContactUsAdminCmsAsync(command);

            return new JsonResult(result);
        }
       

        public async Task<JsonResult> OnPostCloseTicket()
        {
            var result = await _contactUsClient.CloseTicketContactUsAdminCmsAsync(new CloseContactUsCommand()
            {
                Message = CloseRequestModel.Message?.Trim(),
                RequestId = Guid.Parse(CloseRequestModel.Id)
            });

            return new JsonResult(result);
        }

        private (bool, string) CheckFileValidation(IFormFile attachedFile)
        {
            

            var checkFileLengthAndExtentionResult = CheckFileLengthAndExtention(attachedFile);
            if (!string.IsNullOrEmpty(checkFileLengthAndExtentionResult))
                return (false, checkFileLengthAndExtentionResult);

            else
                return (true, string.Empty);

        }

        [HttpGet]
        public async Task<IActionResult> OnGetDownloadFile(string contactusId, string fileId)
        {

            var file = await _contactUsClient.FileContactUsArrayByIdAsync(Guid.Parse(contactusId), Guid.Parse(fileId));
            return new OkObjectResult(file);

        }
      
        private string CheckFileLengthAndExtention(IFormFile file)
        {
            var extention = file.FileName?.Split('.')?.LastOrDefault().ToUpper();

            if (file.Length > 5242880)
                return "الحد الاقصى لحجم الملف لا يزيد عن / " + 5 + " ميجا بايت";


            else if (extention != "PDF" && extention != "PNG" && extention != "JPG" && extention != "jpeg" && extention != "AVI" && extention != "MP4")
                return "مسموح فقط بملفات من نوع pdf ,JPG,AVI,MP4,PNG,jpeg";
            else
                return string.Empty;
        }
        private AddConatctUsReplayAdminCommand ConvertToBinary(IFormFile file, AddConatctUsReplayAdminCommand command)
        {
            command.FileData = new FileCotactUsReplyData();

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                command.FileData.Data = ms.ToArray();

            }
            command.FileData.Name = file.FileName;
            command.FileData.Extension = file.FileName?.Split('.')?.LastOrDefault().ToUpper();
            command.FileData.Size = double.Parse(file.Length.ToString());
            command.FileData.ContentType = file.ContentType;
            return command;
        }
    }
}
