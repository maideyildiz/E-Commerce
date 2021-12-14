using System.Collections.Generic;
using E_Commerce.App.AdminPage.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;

namespace E_Commerce.App.AdminPage.APIServices
{
    public class CategoryService /*: BaseService<CategoryViewModel>, IBaseService<CategoryViewModel>*/
    {
        private readonly BaseService<CategoryViewModel> bs;
        public CategoryService(IWebHostEnvironment webHostEnvirement)
        {
            bs = new BaseService<CategoryViewModel>(webHostEnvirement);
        }
        public List<CategoryViewModel> GetAllCategories()
        {
            CategoryViewModel model = new CategoryViewModel();
            return bs.GetAll(model, "/Categories");
        }
        public CategoryViewModel GetOneCategory(int? id)
        {
            return bs.GetOne(id, "/Categories/");
        }
        public HttpResponseMessage AddCategory(CategoryViewModel model)
        {
            return bs.PostResMethod(model, "/Categories");
        }
        public HttpResponseMessage EditCategory(CategoryViewModel model)
        {
            return bs.EditResMethod(model, "/Categories/", model.Id);
        }
        public HttpResponseMessage DeleteCategory(int? id)
        {
            return bs.DeleteResMethod("/Categories/", id);
        }
        //public CategoryService(IWebHostEnvironment webHostEnvirement) : base(webHostEnvirement)
        //{
        //}
    }
}
