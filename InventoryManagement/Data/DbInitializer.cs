namespace InventoryManagement.Data
{
    public class DbInitializer
    {
        public static void Initialize(InventoryManagementContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Products.Add(new Models.Product()
            {
                //Id = 1,
                Name = "Iphone",
               // Quantity = 100
            });

            context.Purchases.Add(new Models.Purchase()
            {
                ProductId = 1,
                //PurchaseProduct = "Iphone",
                PurchaseQuantity = 10,
                PurchaseDate = DateTime.Now
            });
            context.SaveChanges();
        }
    }
}
