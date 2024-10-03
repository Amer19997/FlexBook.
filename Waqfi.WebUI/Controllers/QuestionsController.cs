using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Data;

namespace WebUI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionsController : ControllerBase
{

    public List<QuestionDataTable> QuestionDataTables = new List<QuestionDataTable>();


    [HttpPost]
    public IActionResult GetCustomers()
    {

        using (StreamReader JSON = new StreamReader(@"E:\Question.json"))
        {
            string json = JSON.ReadToEnd();

             QuestionDataTables = JsonConvert.DeserializeObject<List<QuestionDataTable>>(json);
        }

        //var pageSize = int.Parse(Request.Form["length"]);
        //var skip = int.Parse(Request.Form["start"]);

        //var searchValue = Request.Form["search[value]"];

        //var sortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")];
        //var sortColumnDirection = Request.Form["order[0][dir]"];

        //IQueryable<QuestionDataTable> customers = QuestionDataTables.Where(m => string.IsNullOrEmpty(searchValue)
        //    ? true
        //    : (m.Question.Contains(searchValue) || m.Answar.Contains(searchValue));

        //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        //    customers = QuestionDataTables.OrderBy(string.Concat(sortColumn, " ", sortColumnDirection));

        //var data = customers.Skip(skip).Take(pageSize).ToList();

        //var recordsTotal = customers.Count();

        //var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, data };

        return Ok(QuestionDataTables);
    }
}
