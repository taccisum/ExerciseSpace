using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using CustomerException;
using Global.Configs;
using HelperUnit.Extend;
using HelperUnit.Units;
using Model.Context;
using Model.Entity;
using Practice.Unit;


namespace Repository.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : DTO
    {
        private AccountContext db;
        private DbSet<T> dbSet;

        public GenericRepository()
        {
            db = new AccountContext();
            dbSet = db.Set<T>();
        }


        public IQueryable<T> Get(bool isDeleted = false)
        {
            return Get(t => true, isDeleted);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> expression, bool isDeleted = false)
        {
            if (isDeleted)
            {
                return dbSet.Where(expression);
            }
            else
            {
                return dbSet.Where(t => t.IsDeleted == false).Where(expression);
            }
        }

        public T FirstOrDefault(Expression<Func<T, bool>> expression, bool isDeleted = false)
        {
            return Get(expression, isDeleted).FirstOrDefault();
        }

        public T GetEntryByPrimaryKey(params object[] primaryKey)
        {
            return dbSet.Find(primaryKey);
        }

        public void Insert(T entity)
        {
            entity.ID = Guid.NewGuid();
            entity.CreatedOn = DateTime.Now;
            entity.CreatedBy = CheckCurrentUser().ID;

            dbSet.Add(entity);
        }

        public void Delete(T entity, bool isLogic = true)
        {
            if (isLogic)
            {
                entity.IsDeleted = true;
                Update(entity);
            }
            else
            {
                dbSet.Remove(entity);
            }
        }

        public void Delete(object primaryKey, bool isLogic = true)
        {
            var entity = dbSet.Find(primaryKey);
            Delete(entity, isLogic);
        }

        public void Update(T entity)
        {
            entity.ModifiedOn = DateTime.Now;
            entity.ModifiedBy = CheckCurrentUser().ID;
            db.Entry(entity).State = EntityState.Modified;
        }


        public int Submit()
        {
            return db.SaveChanges();
        }

        private SysUser CheckCurrentUser()
        {
            var currentUser = db.SysUsers.FirstOrDefault(u => u.ID == CookiesHelper.Get(GlobalContext.CURRENT_USER).ToGuid());
            if (currentUser == null)
                throw new CommonException("当前登陆用户不存在");
            return currentUser;
        }

    }
}