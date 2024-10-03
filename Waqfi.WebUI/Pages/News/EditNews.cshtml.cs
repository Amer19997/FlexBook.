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
    public class EditNewsModel : PageModel
    {
        private readonly INewsClient _newsClient;
        private readonly IMapper _mapper;

        [BindProperty]
        public NewsDto NewsDto { get; set; }
        public List<NewsStatusDto> Status { get; set; }
        private const int ImageLegnth = 2097152;

        public EditNewsModel(INewsClient newsClient , IMapper mapper)
        {
            _newsClient = newsClient;
            _mapper = mapper;
        }
        public async Task OnGetAsync(Guid id)
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
            var news = await _newsClient.GetCMSNewsAsync(id);
            NewsDto = _mapper.Map<NewsDto>(news.Result);
        }
        public async Task<JsonResult> OnPostAsync()
        {
            var NewsCommand = _mapper.Map<UpdateNewsCommand>(NewsDto);
            if (NewsDto.EditImage)
            {
                if (NewsDto.ImageDto == null)
                    return new JsonResult(new TResponse() { Errors = new List<string> { "حقل الصوره إجبارى" } });

                List<string> listOfAllowedExtenstions = new List<string> { "JPG", "PNG", "JPEG", "BMP" };

                if (!listOfAllowedExtenstions.Contains(NewsDto?.ImageDto?.FileName?.Split('.').LastOrDefault()?.ToUpper()))
                    return new JsonResult(new TResponse() { Errors = new List<string> { "JPG, PNG, JPEG, BMP نوع الملفات المسموح بها" } });

                if (NewsDto.ImageDto.Length > ImageLegnth)
                    return new JsonResult(new TResponse() { Errors = new List<string> { "الحد الاقصى لحجم صورة لا يزيد عن / 2 ميجا بايت" } });

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
            }
            var result = await _newsClient.UpdateAsync(NewsCommand);
            return new JsonResult(result);

        }

    }
}
