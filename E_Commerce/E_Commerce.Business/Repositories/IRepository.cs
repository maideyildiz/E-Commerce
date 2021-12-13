using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace E_Commerce.Business.Repositories
{
    public interface IRepository<T> where T : class
    {
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
        List<T> GetAll();
        T GetById(int id);
        T Find(Expression<Func<T, bool>> where);
    }
}
