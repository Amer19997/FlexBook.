using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Client;
using WebUI.Data;
using WebUI.IntegrationServices;
using WebUI.Mapping;
using WebUI.Models.Question;

namespace WebUI.Pages.Question
{
    [Authorize(Roles = SystemRoles.ViewQuestionsList + " , " + SystemRoles.SuperAdmin)]
    public class QuestionListModel : PageModel
    {
        private readonly IQuestionsClient _questionsClient;
        public ICollection<GetAllQuestionList> GetAllQuestion { get; set; }

        public GetQuestionsListResult QuestionViewModels { get; set; }
        public string? QuestionName { get; set; }

        public QuestionListModel(IQuestionsClient questionsClient)
        {
            _questionsClient = questionsClient;
           
        }

        public async Task OnGet()
        {
            QuestionViewModels = await _questionsClient.GetAllQuestionsAsync("",0);
        }

        public async Task<JsonResult> OnPostGetAjax(string questionSearch)
        {

            var PageNumber = int.Parse(Request.Form["draw"]);
            var skip = int.Parse(Request.Form["start"]);

           
            var Questions = await _questionsClient.GetAllQuestionsAsync(questionSearch, pageNumber: skip);


            var date = Questions.EmployeeItems.Select(e => new QuestionViewModel()
            {
                QuestionCreate = e.QuestionCreate.ToString("dd MMM yyyy", CultureInfo.CreateSpecificCulture("AR-AR")),
                QuestionId = e.QuestionId.ToString(),
                Question = e.Question,
                PriorityNumber = e.PriorityNumber,
                QuestionStatue = (int)e.QuestionStatue == 1 ? "غير فعال" : "فعال",
                Answer = e.Answer,
                CounterPage = skip

            }) ;


            var recordsTotal = Questions.TotalCount;

            var data = Questions.EmployeeItems;

            var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, data = date };

            return new JsonResult(jsonData);


        }

    }
}
