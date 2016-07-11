using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Practice.Unit
{
    public interface IGenericRepository<T>
    {
        /// <summary>
        /// 获取集合的所有记录
        /// </summary>
        /// <param name="isDeleted">是否包括被逻辑删除的条目</param>
        /// <returns></returns>
        IQueryable<T> Get(bool isDeleted = false);
        /// <summary>
        /// 获取集合的记录
        /// </summary>
        /// <param name="expression">筛选条目的lambda表达式</param>
        /// <param name="isDeleted">是否包括被逻辑删除的条目</param>
        /// <returns></returns>
        IQueryable<T> Get(Expression<Func<T, bool>> expression, bool isDeleted = false);

        T FirstOrDefault(Expression<Func<T, bool>> expression, bool isDeleted = false);
        /// <summary>
        /// 通过主键获取记录
        /// </summary>
        /// <param name="primaryKey">键值</param>
        /// <returns></returns>
        T GetEntryByPrimaryKey(params object[] primaryKey);
        /// <summary>
        /// 新增一条记录
        /// </summary>
        /// <param name="entity"></param>
        void Insert(T entity);
        void Delete(T entity, bool isLogic = true);
        void Delete(object primaryKey, bool isLogic = true);
        void Update(T entity);
        int Submit();
    }
}