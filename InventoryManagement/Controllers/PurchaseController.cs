using InventoryManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: PurchaseController
        public ActionResult DisplayPurchase()
        {
            List<Purchase> purchases = new List<Purchase>()
            {
                new Purchase()
                {
                    Id = 1,
                    PurchaseProduct = "Iphone",
                    PurchaseQuantity = 10,
                    PurchaseDate = DateTime.Now,
                },

                new Purchase()
                {
                    Id=2,
                    PurchaseProduct = "Dell Laptop",
                    PurchaseQuantity= 30,
                    PurchaseDate= DateTime.Now,
                }
            };
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
            return View();
        }

        // POST: PurchaseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PurchaseProduct(IFormCollection collection)
        {
            try
            {
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
            return View();
        }

        // POST: PurchaseController/Edit/5
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
