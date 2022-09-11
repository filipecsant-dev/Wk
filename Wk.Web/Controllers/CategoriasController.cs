using Microsoft.AspNetCore.Mvc;

namespace Wk.Web.Controllers
{
    public class CategoriasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
