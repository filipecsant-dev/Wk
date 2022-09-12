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
        private readonly IUOW _uow;
        public CategoriasService(IBaseRepository<Categorias> categoriasRepository, IUOW uow)
        {
            _categoriasRepository = categoriasRepository;
            _uow = uow;
        }

        public IEnumerable<Categorias> GetAll()
        {
            try
            {
                return _categoriasRepository.GetAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Categorias GetById(int id)
        {
            try
            {
                return _categoriasRepository.GetById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Update(Categorias categoria)
        {
            try
            {
                _categoriasRepository.Update(categoria);

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
                var categoria = _categoriasRepository.GetById(id);
                _categoriasRepository.Delete(categoria);
                _uow.Commit();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Create(Categorias categoria)
        {
            try
            {
                _categoriasRepository.Create(categoria);

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


    }
}
