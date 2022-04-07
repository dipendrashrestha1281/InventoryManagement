﻿using InventoryManagement.Data;
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
            _dbcontext.SaveChanges();
        }

        public void DeletePurchase(Purchase purchase)
        {
            _dbcontext.Purchases.Remove(purchase);
        }

        public void EditPurchase(Purchase purchase)
        {
            var PurchaseToEdit = _dbcontext.Purchases.FirstOrDefault(p=>p.PurchaseId==purchase.PurchaseId);
            if (PurchaseToEdit != null)
            {
                throw new Exception("Purchase not found");
            }
            PurchaseToEdit.ProductId = purchase.ProductId;
            //PurchaseToEdit.PurchaseProduct = purchase.PurchaseProduct;
            PurchaseToEdit.PurchaseQuantity = purchase.PurchaseQuantity;
            PurchaseToEdit.PurchaseDate = purchase.PurchaseDate;
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
