using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wk.Domain.Interfaces;
using Wk.Domain.Models;

namespace Wk.Domain.Services
{
    public class CategoriasService
    {
        private readonly IBaseRepository<Categorias> _categoriasRepository;
        public CategoriasService(IBaseRepository<Categorias> categoriasRepository)
        {
            _categoriasRepository = categoriasRepository;
        }


    }
}
