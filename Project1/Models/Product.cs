using System.ComponentModel.DataAnnotations;

namespace Project1.Models
{
    public class Product
    {
        [Key]
        [Required]
       
        public int ProductId { get; set; }
        public int ProducrPrise { get; set; }
        public string ProductName { get; set; } 
        public string ProductDescription { get; set; }
        public Category Category { get; set; }

      


    }
}
