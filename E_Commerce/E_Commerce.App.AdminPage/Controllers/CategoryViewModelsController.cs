using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.App.AdminPage.Models;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace E_Commerce.App.AdminPage.Controllers
{
    public class CategoryViewModelsController : Controller
    {
        Uri baseAdress = new Uri("https://localhost:44340/api");

        HttpClient httpClient;
        public CategoryViewModelsController()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = baseAdress;
        }

        // GET: CategoryViewModels
        public ActionResult Index()
        {
            List<CategoryViewModel> modelList = new List<CategoryViewModel>();
            HttpResponseMessage response = httpClient.GetAsync(baseAdress + "/Categories").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<CategoryViewModel>>(data);
            }
            return View(modelList);
        }

        // GET: CategoryViewModels/Details/5
        public ActionResult Details(int? id)
        {
            CategoryViewModel model = new CategoryViewModel();
            HttpResponseMessage response = httpClient.GetAsync(baseAdress + "/Categories/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<CategoryViewModel>(data);
            }
            return View(/*"Create" + */model);
        }

        // GET: ProductViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PostAsync(baseAdress + "/Categories", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: CategoryViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            CategoryViewModel model = new CategoryViewModel();
            HttpResponseMessage response = httpClient.GetAsync(baseAdress + "/Categories/+id").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<CategoryViewModel>(data);
            }
            return View(/*"Create" + */model);
        }

        // POST: CategoryViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PutAsync(baseAdress + "/Categories/" + model.Id, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create", model);
        }

        //GET: CategoryViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            HttpResponseMessage response = httpClient.DeleteAsync(baseAdress + "/Categories/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //// POST: CategoryViewModels/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    var categoryViewModel = await _context.CategoryViewModel.FindAsync(id);
        //    _context.CategoryViewModel.Remove(categoryViewModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

    }
}
