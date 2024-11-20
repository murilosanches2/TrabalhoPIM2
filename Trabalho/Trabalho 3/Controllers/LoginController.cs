using Microsoft.AspNetCore.Mvc;
using Trabalho_3.Models;
using Trabalho_3.Repositorio;

namespace Trabalho_3.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public LoginController(IUsuarioRepositorio usuarioRepositorio) 
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginmodel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginmodel.Login);

                    if(usuario != null)
                    {
                        if (usuario.SenhaValida(loginmodel.Senha))
                        {
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = $"A senha é inválida! Tente novamente!";
                    }

                    TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s)! Tente novamente!";

                }

                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao efetuar o login! Erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
