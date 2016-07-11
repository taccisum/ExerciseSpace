using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Model.Entity;
using Practice.Unit;
using Repository.GenericRepository;

namespace Repository.GenericRepository
{
    public class GenericRepositoryProxy<T> : IGenericRepository<T> where T : DTO
    {
        private readonly IGenericRepository<T> _baseCrud = new GenericRepository<T>();

        public IQueryable<T> Get(bool isDeleted = false)
        {
            return Get(t => true);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> expression,bool isDeleted = false)
        {
            return _baseCrud.Get(expression);
        }

        public T GetEntryByPrimaryKey(params object[] primaryKey)
        {
            return _baseCrud.GetEntryByPrimaryKey(primaryKey);
        }

        public void Insert(T entity)
        {
            _baseCrud.Insert(entity);
        }

        public void Delete(T entity)
        {
            _baseCrud.Delete(entity);
        }

        public void Delete(object primaryKey)
        {
            _baseCrud.Delete(primaryKey);
        }

        public void Update(T entity)
        {
            _baseCrud.Update(entity);
        }

        public int Submit()
        {
            return _baseCrud.Submit();
        }
    }
}