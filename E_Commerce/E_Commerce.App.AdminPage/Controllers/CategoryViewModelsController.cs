using Microsoft.AspNetCore.Mvc;
using E_Commerce.App.AdminPage.Models;
using Microsoft.AspNetCore.Hosting;
using E_Commerce.App.AdminPage.APIServices;

namespace E_Commerce.App.AdminPage.Controllers
{
    public class CategoryViewModelsController : Controller
    {
        private readonly CategoryService _cr;
        public CategoryViewModelsController(IWebHostEnvironment webHostEnvirement)
        {
            _cr = new CategoryService(webHostEnvirement);
        }

        // GET: CategoryViewModels
        public ActionResult Index()
        {
            return View(_cr.GetAllCategories());
        }

        // GET: CategoryViewModels/Details/5
        public ActionResult Details(int? id)
        {
            return View(_cr.GetOneCategory(id));
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
            if (_cr.AddCategory(model).IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: CategoryViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            return View(_cr.GetOneCategory(id));
        }

        // POST: CategoryViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel model)
        {
            if (_cr.EditCategory(model).IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create", model);
        }

        //GET: CategoryViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (_cr.DeleteCategory(id).IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
