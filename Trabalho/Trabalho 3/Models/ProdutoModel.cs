using System.ComponentModel.DataAnnotations;
using Trabalho_3.Enums;

namespace Trabalho_3.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Insira o produto")]
        public string Produto { get; set; }
        [Required(ErrorMessage = "Insira a quantidade")]
        [Phone(ErrorMessage = "Quantidade inválida")]
        public string Quantidade { get; set; }
        [Required(ErrorMessage = "Insira o tipo")]
        public TipoEnum? Tipo { get; set; }
        [Required(ErrorMessage = "Insira o total")]
        [Phone(ErrorMessage = "Total inválido")]
        public string Total { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

    }
}
