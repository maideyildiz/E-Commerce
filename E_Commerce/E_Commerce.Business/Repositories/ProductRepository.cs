using E_Commerce.Data.Data;
using E_Commerce.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace E_Commerce.Business.Repositories
{
    public class ProductRepository :IRepository<ProductEntity>
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<ProductEntity> _dbSet;
        private readonly CategoryRepository _category;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
            _category=new CategoryRepository(context);
            _dbSet = _context.Set<ProductEntity>();
        }
        public int Add(ProductEntity entity)
        {
            _dbSet.Add(entity);
            return _context.SaveChanges();
        }

        public int DeleteProduct(int id)
        {
            if (id != 0)
            {
                ProductEntity p = Find(x => x.Id == id);
                return Delete(p);
            }
            else
            {
                return -1;
            }
        }
        public int Delete(ProductEntity entity)
        {
            _dbSet.FirstOrDefault(i => i.Id == entity.Id);
            _dbSet.Remove(entity);
            return _context.SaveChanges();
        }
        public int FindIdFromName(string cName)
        {
            //var ct=_context.Set<CategoryEntity>().SingleOrDefault(x => x.Name == cName);/*Find(x => x.Name == cName); */
            var item = _context.Set<CategoryEntity>().Select(m => new CategoryEntity()
            {
                Id = m.Id,
                Name = m.Name,
            }).SingleOrDefault(x => x.Name == cName);
            return item.Id;
        }
        public ProductEntity Find(Expression<Func<ProductEntity, bool>> where)
        {
            return _dbSet.FirstOrDefault(where);
        }
        public List<ProductEntity> GetAll()
        {
            var list = _dbSet.Include(x => x.Category).Select(m => new ProductEntity()
            {
                Id = m.Id,
                Name = m.Name,
                Price = m.Price,
                PictureURL = m.PictureURL,
                Total = m.Total,
                Details = m.Details,
                CategoryId = m.CategoryId,
                CategoryName = m.Category.Name
            }).ToList();

            return list;
        }
        public List<CategoryEntity> GetCategories()
        {
            var item = _context.Set<CategoryEntity>().Select(m => new CategoryEntity()
            {
                Id = m.Id,
                Name = m.Name,
            }).ToList();
            return item;
        }
        public ProductEntity GetById(int id)
        {
            var item=_dbSet.Include(c => c.Category).Select(m => new ProductEntity()
            {
                Id = m.Id,
                Name = m.Name,
                Price = m.Price,
                PictureURL = m.PictureURL,
                Total = m.Total,
                Details = m.Details,
                CategoryId = m.CategoryId,
                CategoryName = m.Category.Name
            }).SingleOrDefault(i => i.Id == id);
            return item;
        }

        public int UpdateProduct(int id,ProductEntity entity)
        {
            ProductEntity p=Find(x=>x.Id==id);
            p.Name=entity.Name;
            p.Total=entity.Total;
            p.PictureURL = entity.PictureURL;
            p.Price=entity.Price;
            p.Details=entity.Details;
            p.CategoryId = entity.CategoryId;
            //p.Category=entity.Category;
            return Update(p);
        }
        public int Update(ProductEntity entity)
        {
            return _context.SaveChanges();
        }
    }
}
