using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;
public class DonatorsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
