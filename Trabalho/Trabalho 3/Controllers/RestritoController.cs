using Microsoft.AspNetCore.Mvc;
using Trabalho_3.Filters;

namespace Trabalho_3.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
