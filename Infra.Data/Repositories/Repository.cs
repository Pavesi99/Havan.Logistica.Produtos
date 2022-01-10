﻿using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;

        protected Repository(DbContext context)
        {
            _dbSet = context.Set<T>();
        }

        public void Add(T obj)
        {
            _dbSet.Add(obj);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Update(T obj)
        {
            _dbSet.Update(obj);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public void Remove(object id)
        {
            T exists = _dbSet.Find(id);
            _dbSet.Remove(exists);
        }

        public void Remove(T entities)
        {
            _dbSet.Remove(entities);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }
    }
}