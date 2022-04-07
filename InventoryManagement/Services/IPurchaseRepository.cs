using InventoryManagement.Models;

namespace InventoryManagement.Services
{
    public interface IPurchaseRepository
    {
        IEnumerable<Purchase> GetPurchases();
        Purchase GetPurchaseByID(int purchaseId);

        void AddPurchase(Purchase purchase);
        void EditPurchase(Purchase purchase);
        void DeletePurchase(Purchase purchase);

    }
}
