using System.ComponentModel.DataAnnotations;
using Trabalho_3.Enums;

namespace Trabalho_3.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Insira o Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Insira o Login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Insira o E-mail")]
        [EmailAddress(ErrorMessage = "O E-mail informado não é valido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe o Perfil")]
        public PerfilEnum? Perfil { get; set; }
    }
}
