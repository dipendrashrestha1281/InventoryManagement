using InventoryManagement.Data;
using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Services
{
   
    public class PurchaseRepository : IPurchaseRepository
    {
        private InventoryManagementContext _dbcontext;

        public PurchaseRepository(InventoryManagementContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void AddPurchase(Purchase purchase)
        {
            _dbcontext.Purchases.Add(purchase);
            var UpdatedQuantity = _dbcontext.Products.FirstOrDefault(p => p.Id == purchase.ProductId);
            UpdatedQuantity.Quantity = UpdatedQuantity.Quantity + purchase.PurchaseQuantity;
            _dbcontext.SaveChanges();

        }

        public void DeletePurchase(Purchase purchase)
        {
            _dbcontext.Purchases.Remove(purchase);
        }

        public void EditPurchase(Purchase purchase, int quantity)
        {
            var PurchaseToEdit = _dbcontext.Purchases.FirstOrDefault(p=>p.PurchaseId==purchase.PurchaseId);
            if (PurchaseToEdit == null)
            {
                throw new Exception("Purchase not found");
            }
            //PurchaseToEdit.ProductId = purchase.ProductId;
            //PurchaseToEdit.PurchaseProduct = purchase.PurchaseProduct;
            PurchaseToEdit.PurchaseQuantity = purchase.PurchaseQuantity;
            PurchaseToEdit.PurchaseDate = DateTime.Now;
            var UpdatedQuantity = _dbcontext.Products.FirstOrDefault(p => p.Id == PurchaseToEdit.ProductId);
            UpdatedQuantity.Quantity = UpdatedQuantity.Quantity + PurchaseToEdit.PurchaseQuantity - quantity;
            _dbcontext.SaveChanges();
        }

        public Purchase GetPurchaseByID(int purchaseId)
        {
            return _dbcontext.Purchases.FirstOrDefault(p => p.PurchaseId == purchaseId);
        }

        public IEnumerable<Purchase> GetPurchases()
        {
            return _dbcontext.Purchases.Include(p => p.ProductPurchased).ToList();
        }
    }
}
