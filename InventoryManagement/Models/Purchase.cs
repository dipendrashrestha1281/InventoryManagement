using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        [Display(Name ="Product")]
        public string PurchaseProduct { get; set; }

        [Display(Name ="Quantity")]
        
        public int PurchaseQuantity { get; set; }

        [Display(Name ="Date")]
        [DataType(DataType.DateTime)]
        public DateTime PurchaseDate { get; set; }
    }
}
