using Microsoft.AspNetCore.Mvc;

namespace Wk.Web.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
