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
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly WkContext _context;
        public BaseRepository(WkContext context)
        {
            _context = context;
        }

        public virtual TEntity GetById(int id)
        {
            var query = _context.Set<TEntity>().Where(e => e.ID == id);
            if (query.Any())
                return query.FirstOrDefault();
            return null;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            var query = _context.Set<TEntity>();
            if (query.Any())
                return query.ToList();
            return new List<TEntity>();
        }

        public virtual void Save(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }
    }
}
