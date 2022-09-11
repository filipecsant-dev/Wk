using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wk.Domain.Models;
using Wk.Infrastructure.Context;

namespace Wk.Infrastructure.Repository
{
    public class CategoriasRepository : BaseRepository<Categorias>
    {
        public CategoriasRepository(WkDbContext context) : base(context) { }


        public override Categorias GetById(int id)
        {
            var query = _context.Set<Categorias>().Where(e => e.ID == id);

            if (query.Any())
                return query.First();

            return null;
        }

        public override IEnumerable<Categorias> GetAll()
        {
            var query = _context.Set<Categorias>();

            return query.Any() ? query.ToList().Where(x => x.ATIVO == true) : new List<Categorias>();
        }

        public override void Update(Categorias categoria)
        {
            _context.Attach(categoria);
            _context.Entry(categoria).State = EntityState.Modified;
        }

        public override void Delete(Categorias entityToDelete)
        {
            entityToDelete.ATIVO = false;
            Update(entityToDelete);
        }

        public override void Create(Categorias entity)
        {
            _context.Add(entity);
        }


    }
}
