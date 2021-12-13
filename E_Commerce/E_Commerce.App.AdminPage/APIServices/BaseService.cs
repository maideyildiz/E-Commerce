using System;
using System.Collections.Generic;
using E_Commerce.App.AdminPage.Models;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerce.App.AdminPage.APIServices
{
    public class BaseService<T> where T : class,new()
    {
        public readonly IWebHostEnvironment _webHostEnvirement;
        public Uri baseAdress = new Uri("https://localhost:44340/api");

        public HttpClient httpClient;
        public BaseService(IWebHostEnvironment webHostEnvirement)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = baseAdress;
            _webHostEnvirement = webHostEnvirement;
        }
        public StringContent StData(T type)
        {
            string data = JsonConvert.SerializeObject(type);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            return content;
        }
        public List<T> GetAll(T type,string url)
        {
            List<T> modelList = new List<T>();
            HttpResponseMessage response = httpClient.GetAsync(baseAdress + url).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<T>>(data);
            }
            return modelList;
        }
        public T GetOne(int? id,string url)
        {
            T model = new T();
            HttpResponseMessage response = httpClient.GetAsync(baseAdress + url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<T>(data);
            }
            return model;
        }
        public HttpResponseMessage PostResMethod(T type, string url)
        {
            HttpResponseMessage response = httpClient.PostAsync(baseAdress + url, StData(type)).Result;

            return response;
        }
        public HttpResponseMessage EditResMethod(T type, string url,int id)
        {
            HttpResponseMessage response = httpClient.PutAsync(baseAdress + url + id, StData(type)).Result;

            return response;
        }
        public HttpResponseMessage DeleteResMethod(string url, int? id)
        {
            HttpResponseMessage response = httpClient.DeleteAsync(baseAdress + url + id).Result;

            return response;
        }
    }
}
