using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage ="Please enter a name with more than two letters")]
        [MinLength(2)]
        
        public string Name { get; set; }

        public int Quantity { get; set; }
        
        
    }
}
