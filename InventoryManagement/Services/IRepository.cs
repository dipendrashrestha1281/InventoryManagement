using InventoryManagement.Models;

namespace InventoryManagement.Services
{
    public interface IRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int productId);

        void AddProduct(Product product);
        void EditProduct(Product product);
        void DeleteProduct(Product product);
    }
}
