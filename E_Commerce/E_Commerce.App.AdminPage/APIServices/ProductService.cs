using System.Collections.Generic;
using E_Commerce.App.AdminPage.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerce.App.AdminPage.APIServices
{
    public class ProductService
    {
        private readonly BaseService<ProductViewModel> bs;
        public ProductService(IWebHostEnvironment webHostEnvirement)
        {
            bs=new BaseService<ProductViewModel>(webHostEnvirement);
        }
        
        public List<ProductViewModel> GetProducts()
        {
            ProductViewModel model = new ProductViewModel();
            return bs.GetAll(model, "/Products");
        }
        public ProductViewModel GetOneProduct(int? id)
        {
            return bs.GetOne(id, "/Products/");
        }
        public ProductViewModel DropList()
        {
            ProductViewModel model = new ProductViewModel();
            string list = "https://localhost:44340/Categories/";
            HttpResponseMessage _ct = bs.httpClient.GetAsync(list).Result;
            string _ls = _ct.Content.ReadAsStringAsync().Result;
            var obj = JsonConvert.DeserializeObject<List<CategoryViewModel>>(_ls);
            model.CategoryList = new SelectList(obj, "Id", "Name");

            return model;
        }
        public ProductViewModel ImgSet(ProductViewModel model)
        {
            string folder;
            if (model.ProductImg != null)
            {
                folder = "Products/";
                //string deneme= Guid.NewGuid().ToString();
                folder += model.ProductImg.FileName/*+Guid.NewGuid().ToString()*/;
                model.PictureURL = "/" + folder;
                string serverFolder = Path.Combine(bs._webHostEnvirement.WebRootPath, folder);
                model.ProductImg.CopyTo(new FileStream(serverFolder, FileMode.Create));
            }
            else if (model.PictureLink != null)
            {
                model.PictureURL = model.PictureLink;
            }
            return model;
        }
        public HttpResponseMessage SaveProduct(ProductViewModel model)
        {
            model = ImgSet(model);
            return bs.PostResMethod(model, "/Products");
        }
        public HttpResponseMessage EditProduct(ProductViewModel model)
        {
            model = ImgSet(model);
            return bs.EditResMethod(model, "/Products/", model.Id);
        }
        public HttpResponseMessage DeleteProduct(int? id)
        {
            return bs.DeleteResMethod("/Products/", id);
        }
    }
}
