using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Data
{
    public class InventoryManagementContext: DbContext
    {
        public InventoryManagementContext(DbContextOptions<InventoryManagementContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
