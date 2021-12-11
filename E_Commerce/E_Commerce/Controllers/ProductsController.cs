using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Data.Entities;
using E_Commerce.Business.Repositories;
using E_Commerce.Data.Data;

namespace E_Commerce.App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ProductRepository _repository;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
            _repository = new ProductRepository(context);
        }

        //GET: api/Products
        [HttpGet]
        public List<ProductEntity> GetProducts()
        {
            return _repository.GetAllProducts();
        }

        //GET: api/Products/5
        [HttpGet("{id}")]
        public ProductEntity GetProductEntity(int id)
        {
            return _repository.GetProductById(id);
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
            return _repository.AddProduct(productEntity);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public int DeleteProductEntity(int id)
        {
            return _repository.DeleteProduct(id);
        }

    }
}
