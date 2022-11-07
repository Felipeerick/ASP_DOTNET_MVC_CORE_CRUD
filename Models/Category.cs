using System.ComponentModel.DataAnnotations;
namespace projeto_web.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        [Display(Name = "Nome da categoria")]
        public string Name { get; set; }

        public ICollection<Product> Products {get; set;}
    }
}