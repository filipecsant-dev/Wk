using System.ComponentModel.DataAnnotations;

namespace Wk.Web.Models
{
    public class CadastroCategoriaVM
    {
        [Required(ErrorMessage = "Necessário o nome do produto.")]
        [MaxLength(20, ErrorMessage = "Nome do produto muito longo.")]
        [MinLength(5, ErrorMessage = "Nome do produto muito curto.")]
        public string Nome { get; set; }
    }

    public class EditarCategoriaVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Necessário o nome do produto.")]
        [MaxLength(20, ErrorMessage = "Nome do produto muito longo.")]
        [MinLength(5, ErrorMessage = "Nome do produto muito curto.")]
        public string Nome { get; set; }
    }

    public class GetCategoriaVM
    {
        public int ID { get; set; }
        public string Nome { get; set; }
    }

}
