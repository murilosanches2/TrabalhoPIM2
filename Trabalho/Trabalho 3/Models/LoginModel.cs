using System.ComponentModel.DataAnnotations;

namespace Trabalho_3.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Insira o login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Insira a aenha")]
        public string Senha { get; set; }
    }
}
