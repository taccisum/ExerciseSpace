using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Practice.Unit
{
    public interface IGenericRepository<T>
    {
        IQueryable<T> Get(Expression<Func<T, bool>> expression);
        T GetById(object primaryKey);



        void Insert(T entity);
        void Delete(T entity);
        void Delete(object primaryKey);
        void Update(T entity);
        int Submit();
    }
}