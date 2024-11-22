using Microsoft.AspNetCore.Mvc;
using Trabalho_3.Models;
using Trabalho_3.Repositorio;

namespace Trabalho_3.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _ProdutoRepositorio;

        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _ProdutoRepositorio = produtoRepositorio;
        }

        public IActionResult Index()
        {
            List<ProdutoModel> produto = _ProdutoRepositorio.BuscarTodos();
            return View(produto);
        }

        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            ProdutoModel produto = _ProdutoRepositorio.ListarPorId(id);
            return View(produto);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            ProdutoModel produto = _ProdutoRepositorio.ListarPorId(id);
            return View(produto);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagar = _ProdutoRepositorio.Apagar(id);
                if (apagar)
                {
                    TempData["MensagemSucesso"] = "Produto deletado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao deletar o produto!";
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao deletar o produto! Erro: {ex.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Criar(ProdutoModel produtoo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    produtoo = _ProdutoRepositorio.Adicionar(produtoo);
                    TempData["MensagemSucesso"] = "Produto registrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(produtoo);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Falha ao registrar o produto! Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ProdutoModel produtoo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ProdutoRepositorio.Atualizar(produtoo);
                    TempData["MensagemSucesso"] = "Produto alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Editar", produtoo);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Falha ao alterar o Produto! Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
