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
            var resultado = (from p in _context.Produtos
                             from c in _context.Categorias.Where(x => x.ID == p.CategoriaID).DefaultIfEmpty()
                             where p.ATIVO == true && p.ID == id
                             select new Produtos
                             {
                                 ID = p.ID,
                                 Nome = p.Nome,
                                 Descricao = p.Descricao,
                                 Qntd = p.Qntd,
                                 CategoriaID = p.CategoriaID,
                                 Categoria = c
                             }).FirstOrDefault();

            return resultado;
        }

        public override IEnumerable<Produtos> GetAll()
        {
            var resultado = (from p in _context.Produtos
                             from c in _context.Categorias .Where(x => x.ID == p.CategoriaID).DefaultIfEmpty()
                             where p.ATIVO == true
                             select new Produtos
                             {
                                 ID = p.ID,
                                 Nome = p.Nome,
                                 Descricao = p.Descricao,
                                 Qntd = p.Qntd,
                                 CategoriaID = p.CategoriaID,
                                 Categoria = c
                             });

            return resultado;
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
