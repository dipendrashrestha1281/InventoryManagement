using InventoryManagement.Data;
using InventoryManagement.Models;
using InventoryManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    public class ProductController : Controller
    {
        private IRepository _repository;
        public ProductController(IRepository repository)
        {
            _repository=repository;
        }
        //private InventoryManagementContext _inventoryManagementContext;
        //public ProductController(InventoryManagementContext inventoryManagementContext)
        //{
        //    _inventoryManagementContext = inventoryManagementContext;
        //}
        // GET: ProductController
        public ActionResult DisplayProduct()
        {
            var products = _repository.GetProducts();
            //DbInitializer.Initialize(_inventoryManagementContext);
            //var products = _inventoryManagementContext.Products.ToList();

            //List<Product> products = new List<Product>()
            //{
            //    new Product()
            //    {
            //        Id = 1,
            //        Name = "Iphone",
            //        Quantity = 10
            //    },

            //    new Product()
            //    {
            //        Id=2,
            //        Name = "Dell Laptop",
            //        Quantity= 30
            //    }
            //};
            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult AddProduct()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Product/AddProduct")]
        public ActionResult AddProductPost(Product product)
        {
            try
            {
                _repository.AddProduct(product);
                //_inventoryManagementContext.Products.Add(product);
                //_inventoryManagementContext.SaveChanges();
                return RedirectToAction(nameof(DisplayProduct));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
