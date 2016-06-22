﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Model.Context;
using Model.Models;
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


        public IQueryable<T> Get(Expression<Func<T,bool>> expression)
        {
            return dbSet.Where(expression);
        }

        public T GetById(object primaryKey)
        {
            return dbSet.Find(primaryKey);
        }

        public void Insert(T entity)
        {
            entity.ID = Guid.NewGuid();

            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Delete(object primaryKey)
        {
            dbSet.Remove(dbSet.Find(primaryKey));
        }

        public void Update(T entity)
        {

        }


        public int Submit()
        {
            return db.SaveChanges();
        }

    }
}