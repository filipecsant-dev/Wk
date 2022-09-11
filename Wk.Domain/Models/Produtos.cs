using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk.Domain.Models
{
    public class Produtos : BaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Qntd { get; set; }
        [ForeignKey("Categorias")]
        public string Categoria { get; set; }
    }
}
