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
            _FornecedorRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(FornecedorModel fornecedor)
        {
            _FornecedorRepositorio.Adicionar(fornecedor);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(FornecedorModel fornecedor)
        {
            _FornecedorRepositorio.Atualizar(fornecedor);
            return RedirectToAction("Index");
        }

    }
}