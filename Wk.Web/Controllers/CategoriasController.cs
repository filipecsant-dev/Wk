using Microsoft.AspNetCore.Mvc;
using Wk.Domain.Models;
using Wk.Domain.Services;
using Wk.Web.Models;

namespace Wk.Web.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly CategoriasService _categoriasService;

        public CategoriasController(CategoriasService categoriasService)
        {
            _categoriasService = categoriasService;
        }


        public IActionResult Index()
        {
            var Categorias = _categoriasService.GetAll();
            return View(Categorias);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastroCategoriaVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    Categorias categoria = new Categorias()
                    {
                        Nome = model.Nome,
                        ATIVO = true
                    };

                    var retorno = _categoriasService.Create(categoria);

                    if (retorno) return RedirectToAction("Index", "Categorias");
                    else
                        ModelState.AddModelError("", "Ocorreu um erro ao salvar o categoria.");
                }

                return View(model);


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        public IActionResult Editar(int id)
        {
            var categoria = _categoriasService.GetById(id);
            var editcategoria = new EditarCategoriaVM()
            {
                ID = categoria.ID,
                Nome = categoria.Nome
            };

            return View(editcategoria);
        }

        [HttpPost]
        public IActionResult Editar(EditarCategoriaVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    Categorias categoria = new Categorias()
                    {
                        ID = model.ID,
                        Nome = model.Nome,
                        ATIVO = true
                    };

                    var retorno = _categoriasService.Update(categoria);

                    if (retorno) return RedirectToAction("Index", "Categorias");
                    else
                        ModelState.AddModelError("", "Ocorreu um erro ao salvar o categoria.");
                }

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
            var categoria = _categoriasService.GetById(id);
            return Json(categoria);
        }

        [HttpPost]
        public void Excluir(int id)
        {
            try
            {
                _categoriasService.Delete(id);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
