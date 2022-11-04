namespace projeto_web.Models
{
    public class Moviment
    {
        public int Id { get; set; }

        public int Product_id {get; set;}
        
        public string? NameMoviment {get; set;}

        public int Quantity { get; set; }

        public Product? Product {get; set;}

        public string? DateMoviment {get; set;}

         public string? Description {get; set;}
    }
}