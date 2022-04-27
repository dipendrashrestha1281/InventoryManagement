using InventoryManagement.Data;
using InventoryManagement.Models;
using InventoryManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    public class ProductController : Controller
    {
        private IRepository _repository;
        //public ProductController(IRepository repository)
        //{
        //    _repository=repository;
        //}
        private InventoryManagementContext _inventoryManagementContext;
        public ProductController(InventoryManagementContext inventoryManagementContext, IRepository repository)
        {
            _inventoryManagementContext = inventoryManagementContext;
            _repository = repository;
        }
        // GET: ProductController
        [Authorize()]
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
            if (ModelState.IsValid)
            {
                _repository.AddProduct(product);
                Purchase purchase = new Purchase();
                purchase.ProductId = product.Id;
                //purchase.PurchaseProduct = product.Name;
                purchase.PurchaseQuantity = product.Quantity;
                purchase.PurchaseDate = DateTime.Now;
                _inventoryManagementContext.Purchases.Add(purchase);
                _inventoryManagementContext.SaveChanges();
                //_inventoryManagementContext.Products.Add(product);
                //_inventoryManagementContext.SaveChanges();
                return RedirectToAction(nameof(DisplayProduct));
            }
            else
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var model= _repository.GetProductById(id);
            return View(model);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        
        public ActionResult Edit(Product product,int id)
        {
            if (ModelState.IsValid)
            {
                _repository.EditProduct(product);
                return RedirectToAction(nameof(DisplayProduct));
            }
            else
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var obj = _repository.GetProductById(id);
            return View(obj);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Product/Delete")]
        public ActionResult DeletePost(int id)
        {
            var obj = _repository.GetProductById(id);
            _repository.DeleteProduct(obj);
            return RedirectToAction("DisplayProduct");
        }
    }
}
