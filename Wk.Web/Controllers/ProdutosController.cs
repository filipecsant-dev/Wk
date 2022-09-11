using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wk.Domain.Interfaces;
using Wk.Domain.Models;
using Wk.Domain.Services;
using Wk.Web.Models;

namespace Wk.Web.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ProdutosService _produtosService;

        public ProdutosController(ProdutosService produtosService)
        {
            _produtosService = produtosService;
        }


        public IActionResult Index()
        {
            var produtos = _produtosService.GetAll();
            return View(produtos);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastroProdutoVM model)
        {
            try
            {
                //if (ModelState.IsValid)
                //{


                //    if ()
                //        return RedirectToAction("Cadastrar", "Produtos");
                //    else
                //        ModelState.AddModelError("", retorno.Msg);
                //}

                return View(model);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        public JsonResult Visualizar(int id)
        {
            var produto = _produtosService.GetById(id);
            return Json(produto);
        }
    }
}
