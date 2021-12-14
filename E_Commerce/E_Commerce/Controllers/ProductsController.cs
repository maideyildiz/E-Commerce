using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.Data.Entities;
using E_Commerce.Business.Repositories;
using E_Commerce.Data.Data;

namespace E_Commerce.App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductRepository _repository;

        public ProductsController(ApplicationDbContext context)
        {
            _repository = new ProductRepository(context);
        }

        //GET: api/Products
        [HttpGet]
        public List<ProductEntity> GetProducts()
        {
            return _repository.GetWithCName();
        }
        [HttpGet("/Categories/")]
        public List<CategoryEntity> GetCategories()
        {
            return _repository.GetCategories();
        }
        //GET: api/Products/5
        [HttpGet("{id}")]
        public ProductEntity GetProductEntity(int id)
        {
            return _repository.GetById(id);
        }
        [HttpGet("/ProductCategory/{CategoryName}")]
        public int ProductEntityId(string CategoryName)
        {
            return _repository.FindIdFromName(CategoryName);
        }
        // PUT: api/Products/5
        [HttpPut("{id}")]
        public int PutProductEntity(int id,ProductEntity productEntity)
        {
            return _repository.UpdateProduct(id,productEntity);
        }

        // POST: api/Products
        [HttpPost]
        public int PostProductEntity(ProductEntity productEntity)
        {
            return _repository.Add(productEntity);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public int DeleteProductEntity(int id)
        {
            return _repository.DeleteProduct(id);
        }

    }
}
