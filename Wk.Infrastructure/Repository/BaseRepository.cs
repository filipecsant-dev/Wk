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
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly WkDbContext _context;
        public BaseRepository(WkDbContext context)
        {
            _context = context;
        }

        public virtual TEntity GetById(int id)
        {
            try
            {
                var query = _context.Set<TEntity>().Where(e => e.ID == id);

                return query.First();
            }
                catch (Exception e)
                {
                    throw e;
                }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            try
            {
                var query = _context.Set<TEntity>();
                if (query.Any())
                    return query.ToList().Where(x => x.ATIVO == true);
                return new List<TEntity>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            try
            {
                _context.Attach(entityToUpdate);
                _context.Entry(entityToUpdate).State = EntityState.Modified;

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public virtual void Delete(TEntity entityToDelete)
        {
            try
            {
                entityToDelete.ATIVO = false;
                Update(entityToDelete);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public virtual void Create(TEntity entity)
        {
            try
            {
                _context.Add(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual void Save(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
