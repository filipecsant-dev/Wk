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
                if (ModelState.IsValid)
                {

                    Produtos produto = new Produtos()
                    {
                        Nome = model.Nome,
                        Descricao = model.Descricao,
                        Qntd = model.Qntd,
                        Categoria = model.Categoria,
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
            var produto = _produtosService.GetById(id);
            var editProduto = new EditarProdutoVM()
            {
                ID = produto.ID,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Qntd = produto.Qntd,
                Categoria = produto.Categoria
            };

            return View(editProduto);
        }

        [HttpPost]
        public IActionResult Editar(EditarProdutoVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    Produtos produto = new Produtos()
                    {
                        ID = model.ID,
                        Nome = model.Nome,
                        Descricao = model.Descricao,
                        Qntd = model.Qntd,
                        Categoria = model.Categoria,
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
