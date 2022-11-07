using System.ComponentModel.DataAnnotations;
namespace projeto_web.Models
{
    public class Moviment
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int Product_id {get; set;}
        
        [Required]
        [StringLength(50)]
        [Display(Name = "Nome da Movimentação")]
        public string NameMoviment {get; set;}

        [Required]
        [Display(Name = "Nome da Quantidade")]
        public int Quantity { get; set; }

        public Product Product {get; set;}

        [Required]
        [Display(Name = "Data da Movimentação")]
        public DateTime DateMoviment {get; set;}

        [Required]
        [StringLength(50)]
        [Display(Name = "Descrição da Movimentação")]
         public string Description {get; set;}
    }
}