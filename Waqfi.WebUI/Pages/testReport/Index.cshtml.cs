using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.testReport
{


    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }



        public async Task<JsonResult> OnPostReports([FromBody] Person person)
        {



            return new JsonResult(true);
        }


    }
}
