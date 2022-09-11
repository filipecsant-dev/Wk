using System;
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
        private readonly IUOW _uow;
        public ProdutosService(IBaseRepository<Produtos> produtosRepository, IUOW uow)
        {
            _produtosRepository = produtosRepository;
            _uow = uow;
        }

        public IEnumerable<Produtos> GetAll()
        {
            try
            {
                return _produtosRepository.GetAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Produtos GetById(int id)
        {
            try
            {
                return _produtosRepository.GetById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Update(Produtos produto)
        {
            try
            {
                _produtosRepository.Update(produto);

                if (_uow.Commit() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var produto = _produtosRepository.GetById(id);
                _produtosRepository.Delete(produto);
                _uow.Commit();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Create(Produtos produto)
        {
            try
            {
                _produtosRepository.Create(produto);

                if (_uow.Commit() > 0)
                    return true;
                else 
                    return false;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
