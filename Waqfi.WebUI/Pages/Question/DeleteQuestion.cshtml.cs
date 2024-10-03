using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.IntegrationServices;

namespace WebUI.Pages.Question
{
    [Authorize(Roles = SystemRoles.ViewQuestionsList + " , " + SystemRoles.SuperAdmin)]
    public class DeleteQuestionModel : PageModel
    {
        private readonly IQuestionsClient _questionsClient;

        public DeleteQuestionModel(IQuestionsClient questionsClient)
        {
            _questionsClient = questionsClient;
        }

        public async Task<IActionResult> OnGet(Guid id)
        {
            var result = await _questionsClient.QuestionsDeleteAsync(id);

            if (result.Success)
            {
                TempData["delete"] = "";
                return RedirectToPage("/Question/QuestionList");
            }
                
            
            return Page();
        }

       
    }
}
