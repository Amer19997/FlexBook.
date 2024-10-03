using System.ComponentModel.DataAnnotations;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebUI.Client;
using WebUI.Enums;
using WebUI.IntegrationServices;
using WebUI.Models.Question;

namespace WebUI.Pages.Question
{
    [Authorize(Roles = SystemRoles.ViewQuestionsList + " , " + SystemRoles.SuperAdmin)]
    public class CreateNewQuestionModel : PageModel
    {
        private readonly IQuestionsClient _questionsClient;
        private readonly IMapper _mapper;
        public List<string> Errors { get; set; }

        public SelectList QuestionStatues;

        [BindProperty]
       public CreateQuestionViewModel QuestionModel { get; set; }


        public CreateNewQuestionModel(IQuestionsClient questionsClient, IMapper mapper)
        {
            _questionsClient = questionsClient;
            _mapper = mapper;
            Errors = new List<string>();
        }

        public void OnGet()
        {
            AssignList();
        }

        public async Task<IActionResult>  OnPost()
        {
            AssignList();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var Question = _mapper.Map<AddNewQuestionCommand>(QuestionModel);


            var result = await _questionsClient.QuestionsPostAsync(Question);

            if (!result.Success)
            {
                Errors = result.Errors.ToList();
                foreach (var item in Errors)
                {
                    if(item.Contains("QuestionIsAlreadyExists"))
                    {
                        TempData["Depulicate"] = "";
                        return Page();  
                    }
                }
                return Page();
            }
            else
            {
                TempData["sweet"] = "";
                return RedirectToPage("/Question/QuestionList");

            }

        }

        private void AssignList()
        {
            var enumData = from Questionstat e in Enum.GetValues(typeof(Questionstat))
                           select new
                           {

                               ID = (int)e,
                               Name = e.GetType().GetMember(e.ToString()).First().GetCustomAttribute<DisplayAttribute>().Name
                           };

            QuestionStatues = new SelectList(enumData, "ID", "Name");
        }
    }
}
