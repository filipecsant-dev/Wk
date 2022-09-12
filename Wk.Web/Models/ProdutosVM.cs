using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wk.Web.Models
{
    public class CadastroProdutoVM
    {
        [Required(ErrorMessage = "Necessário o nome do produto.")]
        [MaxLength(30, ErrorMessage = "Nome do produto muito longo.")]
        [MinLength(5, ErrorMessage = "Nome do produto muito curto.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Necessário informar a descrição.")]
        [MaxLength(50, ErrorMessage = "Informe uma descrição menor.")]
        [MinLength(10, ErrorMessage = "Informe uma descrição maior.")]
        public string Descricao { get; set; }
        public int Qntd { get; set; }
        [Required(ErrorMessage = "Necessário a categoria.")]
        public int CategoriaID { get; set; }
    }

    public class EditarProdutoVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Necessário o nome do produto.")]
        [MaxLength(30, ErrorMessage = "Nome do produto muito longo.")]
        [MinLength(5, ErrorMessage = "Nome do produto muito curto.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Necessário informar a descrição.")]
        [MaxLength(50, ErrorMessage = "Informe uma descrição menor.")]
        [MinLength(10, ErrorMessage = "Informe uma descrição maior.")]
        public string Descricao { get; set; }
        public int Qntd { get; set; }
        [Required(ErrorMessage = "Necessário a categoria.")]
        public int CategoriaID { get; set; }
    }

    public class GetProdutoVM
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Qntd { get; set; }
        public string Categoria { get; set; }
    }
}
