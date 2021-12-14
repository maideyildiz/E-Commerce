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
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryRepository _repository;

        public CategoriesController(ApplicationDbContext context)
        {
            _repository = new CategoryRepository(context);
        }

        // GET: api/Categories
        [HttpGet]
        public List<CategoryEntity> GetCategories()
        {
            //return await _context.Categories.Include(p=>p.Products).ToListAsync();
            return _repository.GetAll();
        }
        [HttpGet("/WithProducts/")]
        public List<CategoryEntity> GetWithProducts()
        {
            //return await _context.Categories.Include(p=>p.Products).ToListAsync();
            return _repository.GetWithProducts();
        }
        // GET: api/Categories/5
        [HttpGet("{id}")]
        public CategoryEntity GetCategoryEntity(int id)
        {
            return _repository.GetById(id);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public int PutCategoryEntity(int id, CategoryEntity categoryEntity)
        {
            return _repository.UpdateCategory(id, categoryEntity);
        }

        // POST: api/Categories
        [HttpPost]
        public int PostCategoryEntity(CategoryEntity categoryEntity)
        {
            return _repository.Add(categoryEntity);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public int DeleteCategoryEntity(int id)
        {
            return _repository.DeleteCategory(id);
        }
    }
}
