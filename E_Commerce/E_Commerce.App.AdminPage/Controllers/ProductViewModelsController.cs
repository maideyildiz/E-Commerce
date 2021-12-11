﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.App.AdminPage.Models;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace E_Commerce.App.AdminPage.Controllers
{
    public class ProductViewModelsController : Controller
    {
        Uri baseAdress = new Uri("https://localhost:44340/api");

        HttpClient httpClient;
        public ProductViewModelsController()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = baseAdress;
        }

        // GET: ProductViewModels
        public ActionResult Index()
        {
            List<ProductViewModel> modelList = new List<ProductViewModel>();
            HttpResponseMessage response = httpClient.GetAsync(baseAdress + "/Products").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<ProductViewModel>>(data);
            }
            return View(modelList);
        }

        // GET: ProductViewModels/Details/5
        public ActionResult Details(int? id)
        {
            ProductViewModel model = new ProductViewModel();
            HttpResponseMessage response = httpClient.GetAsync(baseAdress + "/Products/"+ id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<ProductViewModel>(data);
            }
            return View(/*"Create" + */model);
        }

        // GET: ProductViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PostAsync(baseAdress + "/Products", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: ProductViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            ProductViewModel model = new ProductViewModel();
            HttpResponseMessage response = httpClient.GetAsync(baseAdress + "/Products/+id").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<ProductViewModel>(data);
            }
            return View(/*"Create" + */model);
        }

        // POST: ProductViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PutAsync(baseAdress + "/Products/" + model.Id, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create", model);
        }

        //GET: CategoryViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            HttpResponseMessage response = httpClient.DeleteAsync(baseAdress + "/Products/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}