using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Wk.Domain.Interfaces;
using Wk.Domain.Models;
using Wk.Domain.Services;
using Wk.Web.Models;

namespace Wk.Web.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ProdutosService _produtosService;
        private readonly CategoriasService _categoriasService;

        public ProdutosController(ProdutosService produtosService,
                                  CategoriasService categoriasService)
        {
            _produtosService = produtosService;
            _categoriasService = categoriasService;
        }


        public IActionResult Index()
        {
            var produtos = _produtosService.GetAll();
            return View(produtos);
        }

        public IActionResult Cadastrar()
        {
            ViewBag.Categoria = _categoriasService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastroProdutoVM model)
        {
            try
            {
                ViewBag.Categoria = _categoriasService.GetAll();

                if (ModelState.IsValid)
                {

                    Produtos produto = new Produtos()
                    {
                        Nome = model.Nome,
                        Descricao = model.Descricao,
                        Qntd = model.Qntd,
                        CategoriaID = model.CategoriaID,
                        ATIVO = true
                    };

                    var retorno = _produtosService.Create(produto);

                    if(retorno) return RedirectToAction("Index", "Produtos");
                    else
                        ModelState.AddModelError("", "Ocorreu um erro ao salvar o produto.");
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
            ViewBag.Categoria = _categoriasService.GetAll();

            var produto = _produtosService.GetById(id);
            var editProduto = new EditarProdutoVM()
            {
                ID = produto.ID,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Qntd = produto.Qntd,
                CategoriaID = produto.CategoriaID
            };

            return View(editProduto);
        }

        [HttpPost]
        public IActionResult Editar(EditarProdutoVM model)
        {
            try
            {
                ViewBag.Categoria = _categoriasService.GetAll();

                if (ModelState.IsValid)
                {

                    Produtos produto = new Produtos()
                    {
                        ID = model.ID,
                        Nome = model.Nome,
                        Descricao = model.Descricao,
                        Qntd = model.Qntd,
                        CategoriaID = model.CategoriaID,
                        ATIVO = true
                    };

                    var retorno = _produtosService.Update(produto);

                    if (retorno) return RedirectToAction("Index", "Produtos");
                    else
                        ModelState.AddModelError("", "Ocorreu um erro ao salvar o produto.");
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
            var produto = _produtosService.GetById(id);
            return Json(produto);
        }

        [HttpPost]
        public void Excluir(int id)
        {
            try
            {
                _produtosService.Delete(id);
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }
    }
}
