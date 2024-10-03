using System;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebUI.Pages.Question
{
    [Authorize(Roles = SystemRoles.ViewQuestionsList + " , " + SystemRoles.SuperAdmin)]
    public class UpdateQuestionModel : PageModel
    {
        private readonly IQuestionsClient _questionsClient;
        private readonly IMapper _mapper;
        public SelectList QuestionStatues;
        public List<string> Errors { get; set; }


        [BindProperty]
        public UpdateQuestion QuestionModel { get; set; }


        public UpdateQuestionModel(IQuestionsClient questionsClient, IMapper mapper)
        {
            _questionsClient = questionsClient;
           _mapper= mapper;
            Errors = new List<string>();
        }

        public async Task<IActionResult> OnGet(Guid Id)
        {
            AssignList();

            var result = await _questionsClient.GetQuestionByIdAsync(id: Id);

            QuestionModel = _mapper.Map<UpdateQuestion>(result);

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            AssignList();
            if (!ModelState.IsValid)
            {
                
                return Page();
            }
            

            var Question = _mapper.Map<UpdateQuestionCommand>(QuestionModel);

            var result = await _questionsClient.UpdateQuestionAsync(Question);

            if (!result.Success)
            {

                Errors = result.Errors.ToList();

                foreach (var item in Errors)
                {
                    if (item.Contains("QuestionIsAlreadyExists"))
                    {
                        TempData["Depulicate"] = "";
                        return Page();
                    }
                }
                return Page();
            }
            else
            {
                TempData["sweet1"] = "";

                return RedirectToPage("/Question/QuestionList");
            }


        }

        public async Task<JsonResult> OnGetDataModal(Guid QuestionId)
        {
            var result =  await _questionsClient.GetQuestionByIdAsync(QuestionId);

            return new JsonResult(result);  

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
