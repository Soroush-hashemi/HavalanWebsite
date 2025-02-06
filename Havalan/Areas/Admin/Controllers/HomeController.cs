using Microsoft.AspNetCore.Mvc;

namespace Havalan.Web.Areas.Admin.Controllers;
public class HomeController : AdminBaseController
{
    public IActionResult Index()
    {
        return View();
    }
}
