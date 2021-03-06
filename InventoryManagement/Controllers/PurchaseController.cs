using InventoryManagement.Data;
using InventoryManagement.Models;
using InventoryManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManagement.Controllers
{
    public class PurchaseController : Controller
    {
        private IPurchaseRepository _purchaseRepository;
        private IRepository _productRepository;

        public PurchaseController(IPurchaseRepository purchaseRepository, IRepository productRepository)
        {
            _productRepository = productRepository;
            _purchaseRepository = purchaseRepository;
        }

        //public PurchaseController(InventoryManagementContext inventoryManagementContext)
        //{
        //    _inventoryManagementContext = inventoryManagementContext;
        //}
        // GET: PurchaseController
        [Authorize()]
        public ActionResult DisplayPurchase()
        {
            //DbInitializer.Initialize(_inventoryManagementContext);
            var purchases = _purchaseRepository.GetPurchases();

            //List<Purchase> purchases = new List<Purchase>()
            //{
            //    new Purchase()
            //    {
            //        ProductId = 1,
            //        PurchaseProduct = "Iphone",
            //        PurchaseQuantity = 10,
            //        PurchaseDate = DateTime.Now,
            //    },

            //    new Purchase()
            //    {
            //        ProductId=2,
            //        PurchaseProduct = "Dell Laptop",
            //        PurchaseQuantity= 30,
            //        PurchaseDate= DateTime.Now,
            //    }
            //};
            //return View(purchases);
            return View(purchases);
        }

        // GET: PurchaseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PurchaseController/Create
        public ActionResult PurchaseProduct()
        {
            var list = _productRepository.GetProducts();
            var selectListItemsAsExtensionMethod = list.Select(p => new SelectListItem(p.Name, p.Id.ToString()));
            //another way of writing this is...
            //var selectListItemsAsLinqKeywordQuery = (from p in list
                                                    //select new SelectListItem(p.ProductId.ToString(), p.PurchaseProduct)).ToList();
            ViewBag.listOfItems = selectListItemsAsExtensionMethod;
            return View();
        }

        // POST: PurchaseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PurchaseProduct(Purchase product)
        {
            try
            {
                _purchaseRepository.AddPurchase(product);
                return RedirectToAction(nameof(DisplayPurchase));
            }
            catch
            {
                return View();
            }
        }

        // GET: PurchaseController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _purchaseRepository.GetPurchaseByID(id);
            var product = _productRepository.GetProductById(model.ProductId);
            ViewBag.product = product.Name;
            return View(model);
        }

        // POST: PurchaseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Purchase product)
        {
            try
            {
                var model = _purchaseRepository.GetPurchaseByID(id);
                var quantityToEdit = model.PurchaseQuantity;
                _purchaseRepository.EditPurchase(product,quantityToEdit);
                return RedirectToAction(nameof(DisplayPurchase));
            }
            catch
            {
                return View();
            }
        }

        // GET: PurchaseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PurchaseController/Delete/5
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
