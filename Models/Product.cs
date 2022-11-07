using System.ComponentModel.DataAnnotations;

namespace projeto_web.Models
{
    public class Product
    { 
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nome do Produto")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Quantidade do Produto")]
        public int Quantity {get; set;}

        [Required]
        [Display(Name = "Valor do Produto")]
        public double Value { get; set; }

        public int Category_id {get; set;}

        public Category Category {get; set;}

        public ICollection<Moviment> Moviments {get; set;}
    }

        
}