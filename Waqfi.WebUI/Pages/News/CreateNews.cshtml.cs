using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.IntegrationServices;
using WebUI.Models.News;

namespace WebUI.Pages.News
{
    [Authorize(Roles = SystemRoles.ViewNewsList + " , " + SystemRoles.SuperAdmin)]
    public class CreateNewsModel : PageModel
    {

        private readonly INewsClient _newsClient;
        public readonly ILookUpClient _lookUpClient;
        public IMapper _mapper;

        [BindProperty]
        public NewsDto NewsDto { get; set; }
        public List<NewsStatusDto> Status { get; set; }

        private const int ImageLegnth = 2097152;

        public CreateNewsModel(INewsClient bannerClient, IMapper mapper)
        {
            this._newsClient = bannerClient;
            _mapper= mapper;
        }
        public async Task OnGet() 
        {
            var NewsStatusQueryResult =await _newsClient.StatusAsync(new NewsStatusQuery());
            if (NewsStatusQueryResult.Success)
            {
                Status = NewsStatusQueryResult.Result.Select(ss => new NewsStatusDto
                {
                    Id = ss.Id,
                    NameAr = ss.NameAr,
                    NameEn = ss.NameEn,
                }).ToList();
            }
        }
        public async Task<JsonResult> OnPostAsync() 
        {
            if (NewsDto.ImageDto == null)
                return new JsonResult(new TResponse() { Errors = new List<string> { "حقل الصوره إجبارى" } });

            List<string> listOfAllowedExtenstions = new List<string> { "JPG", "PNG", "JPEG", "BMP" };

            if (!listOfAllowedExtenstions.Contains(NewsDto?.ImageDto?.FileName?.Split('.').LastOrDefault()?.ToUpper()))
                return new JsonResult(new TResponse() { Errors = new List<string> { "JPG, PNG, JPEG, BMP نوع الملفات المسموح بها" } });

            if (NewsDto.ImageDto.Length > ImageLegnth)
                return new JsonResult ( new TResponse() { Errors = new List<string> { "الحد الاقصى لحجم صورة لا يزيد عن / 2 ميجا بايت" } });

            var NewsCommand = _mapper.Map<AddNewsCommand>(NewsDto);
            NewsCommand.Image = new ImageDto();
            using (var stream = new MemoryStream())
            {
                NewsDto.ImageDto?.CopyTo(stream);
                NewsCommand.Image.Bytes = stream.ToArray();

            }
            NewsCommand.Image.Name = NewsDto.ImageDto?.FileName;
            NewsCommand.Image.Extension = NewsDto.ImageDto?.FileName?.Split('.')?.LastOrDefault()?.ToUpper();
            NewsCommand.Image.Size = NewsDto.ImageDto.Length;
            NewsCommand.Image.ContentType = NewsDto.ImageDto.ContentType;
            var result = await _newsClient.CreateNewsAsync(NewsCommand);
            return new JsonResult(result);

        }

    }
}
