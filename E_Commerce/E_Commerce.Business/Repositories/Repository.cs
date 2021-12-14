using E_Commerce.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace E_Commerce.Business.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly ApplicationDbContext _context;
        public readonly DbSet<T> _dbSet;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public int Add(T entity)
        {
            _dbSet.Add(entity);
            return _context.SaveChanges();
        }
        public int Delete(T entity)
        {
            _dbSet.Remove(entity);
            return _context.SaveChanges();
        }
        public T Find(Expression<Func<T, bool>> where)
        {
            return _dbSet.FirstOrDefault(where);
        }

        public List<T> GetAll()
        {
            //return _dbSet.Set.ToList();
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public int Update(T entity)
        {
            return _context.SaveChanges();
        }
    }
}
