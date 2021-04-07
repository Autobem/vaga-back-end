using Autobem.Application.Interfaces;
using Autobem.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Autobem.Application
{
    public class BaseServiceApp<TEntity> : IBaseServiceApp<TEntity> where TEntity : class
    {
        private readonly IBaseService<TEntity> _service;

        public BaseServiceApp(IBaseService<TEntity> service)
        {
            _service = service
        }

        public void Add(TEntity obj)
        {
            _service.Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _service.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _service.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            _service.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            _service.Update(obj);
        }
    }
}
