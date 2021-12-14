//using E_Commerce.Data.Data;
//using E_Commerce.Data.Entities;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;

//namespace E_Commerce.Business.Repositories
//{
//    public class CategoryRepository : IRepository<CategoryEntity>
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly DbSet<CategoryEntity> _dbSet;
//        public CategoryRepository(ApplicationDbContext context)
//        {
//            _context = context;
//            _dbSet = _context.Set<CategoryEntity>();
//        }
//        public int Add(CategoryEntity entity)
//        {
//            _dbSet.Add(entity);
//            return _context.SaveChanges();
//        }
//        public int DeleteCategory(int id)
//        {
//            if (id != 0)
//            {
//                CategoryEntity c = Find(x => x.Id == id);
//                return Delete(c);
//            }
//            else
//            {
//                return -1;
//            }
//        }
//        public int Delete(CategoryEntity entity)
//        {
//            _dbSet.Remove(entity);
//            return _context.SaveChanges();
//        }

//        public CategoryEntity Find(Expression<Func<CategoryEntity, bool>> where)
//        {
//            return _dbSet.FirstOrDefault(where);
//        }

//        public List<CategoryEntity> GetAll()
//        {
//            return _dbSet.Include(p => p.Products).ToList();
//        }
//        public List<string> GetOnlyNames()
//        {
//            return _dbSet.Select(c => c.Name).ToList();
//        }

//        public CategoryEntity GetById(int id)
//        {
//            //return _context.Set<CategoryEntity>().Include(p => p.Products).SingleOrDefault(i => i.Id == id);
//            return _dbSet.Include(p => p.Products).SingleOrDefault(i => i.Id == id);
//        }
//        public int UpdateCategory(int id, CategoryEntity entity)
//        {
//            CategoryEntity c = Find(x => x.Id == id);
//            c.Name = entity.Name;
//            return Update(c);
//        }
//        public int Update(CategoryEntity entity)
//        {
//            return _context.SaveChanges();
//        }
//    }
//}
