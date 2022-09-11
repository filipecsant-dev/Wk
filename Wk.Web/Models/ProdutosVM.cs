using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wk.Web.Models
{
    public class CadastroProdutoVM
    {
        [Required(ErrorMessage = "Necessário o nome do produto.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Necessário informar a descrição.")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Necessário informar a quantidade.")]
        public int Qntd { get; set; }
        [Required(ErrorMessage = "Necessário a categoria.")]
        public string Categoria { get; set; }
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
