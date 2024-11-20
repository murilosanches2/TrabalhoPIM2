using System.ComponentModel.DataAnnotations;

namespace Trabalho_3.Models
{
    public class FornecedorModel
    {
        public int id {  get; set; }
        [Required(ErrorMessage ="Insira o CNPJ")]
        [Phone(ErrorMessage = "CNPJ inválido")]
        public string CNPJ { get; set; }
        [Required(ErrorMessage = "Insira o Nome da Empresa")]
        public string Empresa { get; set; }
        [Required(ErrorMessage = "Insira o Telefone")]
        [Phone(ErrorMessage = "Telefone inválido")]
        public string Telefone { get; set; }
    }
}
