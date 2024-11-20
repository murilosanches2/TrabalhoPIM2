using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho_3.Models;
using Trabalho_3.Repositorio;

namespace Trabalho_3.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly IFornecedorRepositorio _FornecedorRepositorio;

        public FornecedoresController(IFornecedorRepositorio fornecedorRepositorio) 
        {
            _FornecedorRepositorio = fornecedorRepositorio;
        }

        public IActionResult Index()
        {
            List<FornecedorModel> fornecedor = _FornecedorRepositorio.BuscarTodos();
            return View(fornecedor);
        }
        
        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            FornecedorModel fornecedor = _FornecedorRepositorio.ListarPorId(id);
            return View(fornecedor);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            FornecedorModel fornecedor = _FornecedorRepositorio.ListarPorId(id);
            return View(fornecedor);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagar = _FornecedorRepositorio.Apagar(id);
                if (apagar)
                {
                    TempData["MensagemSucesso"] = "Fornecedor deletado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao deletar o fornecedor!";
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao deletar o fornecedor! Erro: {ex.Message}";
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public IActionResult Criar(FornecedorModel fornecedor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _FornecedorRepositorio.Adicionar(fornecedor);
                    TempData["MensagemSucesso"] = "Fornecedor cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(fornecedor);
            }
            catch (System.Exception erro) 
            {
                TempData["MensagemErro"] = $"Falha ao cadastrar o fornecedor! Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(FornecedorModel fornecedor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _FornecedorRepositorio.Atualizar(fornecedor);
                    TempData["MensagemSucesso"] = "Fornecedor alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Editar", fornecedor);
            }
            catch (System.Exception erro) {
                TempData["MensagemErro"] = $"Falha ao alterar o fornecedor! Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}