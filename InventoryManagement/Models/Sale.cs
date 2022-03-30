using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class Sale
    {
        public int Id { get; set; }

        [Display(Name ="Product")]
        public string SaleProduct { get; set; }

        [Display(Name = "Quantity")]
        public int SaleQuantity { get; set; }

        [Display(Name ="Date")]
        public DateTime SaleDate { get; set; }
    }
}
