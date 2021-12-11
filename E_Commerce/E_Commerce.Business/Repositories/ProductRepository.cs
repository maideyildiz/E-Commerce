using E_Commerce.Data.Data;
using E_Commerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace E_Commerce.Business.Repositories
{
    public class ProductRepository 
    {
        private readonly Repository<ProductEntity> _repository;
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
            _repository = new Repository<ProductEntity>(context);
        }
        public int AddProduct(ProductEntity entity)
        {
            return _repository.Add(entity);
        }

        public int DeleteProduct(int id)
        {
            if (id != 0)
            {
                ProductEntity p = _repository.Find(x => x.Id == id);
                return _repository.Delete(p);
            }
            else
            {
                return -1;
            }
        }

        public List<ProductEntity> GetAllProducts()
        {
            return _repository.GetAll();
        }

        public ProductEntity GetProductById(int id)
        {
            return _repository.GetById(id);
        }

        public int UpdateProduct(int id,ProductEntity entity)
        {
            ProductEntity p=_repository.Find(x=>x.Id==id);
            p.Name=entity.Name;
            p.Total=entity.Total;
            p.PictureURL=entity.PictureURL;
            p.Price=entity.Price;
            p.Details=entity.Details;
            p.CategoryId=entity.CategoryId;
            p.Category=entity.Category;
            return _repository.Update(p);
        }
    }
}
