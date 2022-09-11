using Microsoft.AspNetCore.Mvc;

namespace Wk.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
