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
            var ProductToEdit = _dbcontext.Products.FirstOrDefault(p=> p.Id == product.Id);
            if (ProductToEdit == null)
            {
                throw new Exception("Product not found");
            }
            ProductToEdit.Name = product.Name;
            ProductToEdit.Quantity = product.Quantity;
            _dbcontext.SaveChanges();
        }

        public Product GetProductById(int Id)
        {
            return _dbcontext.Products.FirstOrDefault(p=>p.Id == Id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbcontext.Products;
        }
    }
}
