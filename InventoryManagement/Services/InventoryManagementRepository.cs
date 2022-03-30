using InventoryManagement.Data;
using InventoryManagement.Models;

namespace InventoryManagement.Services
{
    public class InventoryManagementRepository : IRepository
    {
        private InventoryManagementContext _dbcontext;

        public InventoryManagementRepository(InventoryManagementContext dbcontext)
        {
            _dbcontext=dbcontext;
        }

        public void AddProduct(Product product)
        {
            _dbcontext.Products.Add(product);
            _dbcontext.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            _dbcontext.Products.Remove(product);
            _dbcontext.SaveChanges();
        }

        public void EditProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void GetProduct(int productId)
        {
            _dbcontext.Products.FirstOrDefault(p=>p.Id == productId);
            _dbcontext.SaveChanges();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbcontext.Products;
        }
    }
}
