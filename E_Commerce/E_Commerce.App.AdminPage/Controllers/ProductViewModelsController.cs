using Microsoft.AspNetCore.Mvc;
using E_Commerce.App.AdminPage.Models;
using Microsoft.AspNetCore.Hosting;
using E_Commerce.App.AdminPage.APIServices;

namespace E_Commerce.App.AdminPage.Controllers
{
    public class ProductViewModelsController : Controller
    {
        private readonly ProductService _pr;
        public ProductViewModelsController(IWebHostEnvironment webHostEnvirement)
        {
            _pr = new ProductService(webHostEnvirement);
        }

        // GET: ProductViewModels
        public ActionResult Index()
        {
            return View(_pr.GetProducts());
        }

        // GET: ProductViewModels/Details/5
        public ActionResult Details(int? id)
        {
            return View(_pr.GetOneProduct(id));
        }

        // GET: ProductViewModels/Create
        public ActionResult Create()
        {
            return View(_pr.DropList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel model)
        {
            if (_pr.SaveProduct(model).IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int? id)
        {
            ProductViewModel model=_pr.GetOneProduct(id);
            model = _pr.DropList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel model)
        {
            if (_pr.EditProduct(model).IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create", model);
        }

        //GET: CategoryViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (_pr.DeleteProduct(id).IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
