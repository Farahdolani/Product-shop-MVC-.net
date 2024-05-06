using System.ComponentModel.DataAnnotations;

namespace Project1.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int Idcategory { get; set; }
        public string Namecategory { get; set; }
    }
}
