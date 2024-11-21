using Microsoft.AspNetCore.Mvc;
using Trabalho_3.Helper;
using Trabalho_3.Models;
using Trabalho_3.Repositorio;

namespace Trabalho_3.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao) 
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index","Home");
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();

            return RedirectToAction("Index", "Login");
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
                            _sessao.CriarSessaoDoUsuario(usuario);
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
