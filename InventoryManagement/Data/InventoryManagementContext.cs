using InventoryManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Data
{
    public class InventoryManagementContext: IdentityDbContext
    {
        public InventoryManagementContext(DbContextOptions<InventoryManagementContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet <Purchase> Purchases { get; set; }
    }
}
