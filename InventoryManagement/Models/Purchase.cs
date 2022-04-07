using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class Purchase
    {
        [Key]
        [Display(Name ="Purchase ID")]
        public int PurchaseId { get; set; }
        [Required]
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }

        //[Display(Name ="Product")]
        //public string PurchaseProduct { get; set; }

        [Display(Name ="Quantity")]
        
        public int PurchaseQuantity { get; set; }

        [Display(Name ="Date")]
        [DataType(DataType.DateTime)]
        public DateTime PurchaseDate { get; set; }
        public Product ProductPurchased { get; set; }
    }
}
