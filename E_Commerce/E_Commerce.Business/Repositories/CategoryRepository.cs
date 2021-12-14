using E_Commerce.Data.Data;
using E_Commerce.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace E_Commerce.Business.Repositories
{
    public class CategoryRepository : Repository<CategoryEntity>, IRepository<CategoryEntity>
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
        public List<CategoryEntity> GetWithProducts()
        {
            return _dbSet.Include(p => p.Products).ToList();
        }
        public int UpdateCategory(int id, CategoryEntity entity)
        {
            CategoryEntity c = Find(x => x.Id == id);
            c.Name = entity.Name;
            return Update(c);
        }
        public int DeleteCategory(int id)
        {
            if (id != 0)
            {
                CategoryEntity c = Find(x => x.Id == id);
                return Delete(c);
            }
            else
            {
                return -1;
            }
        }
    }
}
