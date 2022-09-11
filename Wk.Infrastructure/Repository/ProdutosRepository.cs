using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wk.Domain.Models;
using Wk.Infrastructure.Context;

namespace Wk.Infrastructure.Repository
{
    public class ProdutosRepository : BaseRepository<Produtos>
    {
        public ProdutosRepository(WkContext context) : base(context)
        { }


    }
}
