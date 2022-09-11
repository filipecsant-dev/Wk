﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wk.Domain.Interfaces;
using Wk.Domain.Models;

namespace Wk.Domain.Services
{
    public class ProdutosService
    {
        private readonly IBaseRepository<Produtos> _produtosRepository;
        public ProdutosService(IBaseRepository<Produtos> produtosRepository)
        {
            _produtosRepository = produtosRepository;
        }

        public IEnumerable<Produtos> GetAll()
        {
            return _produtosRepository.GetAll();
        }
        public Produtos GetById(int id)
        {
            return _produtosRepository.GetById(id);
        }
    }
}
