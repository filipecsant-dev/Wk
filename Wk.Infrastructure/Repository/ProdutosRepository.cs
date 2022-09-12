using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wk.Domain.Interfaces;
using Wk.Domain.Models;
using Wk.Infrastructure.Context;

namespace Wk.Infrastructure.Repository
{
    public class ProdutosRepository : BaseRepository<Produtos>
    {
        public ProdutosRepository(WkDbContext context) : base(context) { }
   

        public override Produtos GetById(int id)
        {
            var query = _context.Set<Produtos>().Where(e => e.ID == id);

            if (query.Any())
                return query.First();

            return null;
        }

        public override IEnumerable<Produtos> GetAll()
        {
            var query = _context.Set<Produtos>();

            return query.Any() ? query.ToList().Where(x => x.ATIVO == true) : new List<Produtos>();
        }

        public override void Update(Produtos produto)
        {
            _context.Attach(produto);
            _context.Entry(produto).State = EntityState.Modified;
        }

        public override void Delete(Produtos entityToDelete)
        {
            entityToDelete.ATIVO = false;
            Update(entityToDelete);
        }

        public override void Create(Produtos entity)
        {
            _context.Add(entity);
        }
    }
}
