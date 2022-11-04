namespace projeto_web.Models
{
    public class Product
    { 
        public int Id { get; set; }

        public string? Name { get; set; }   

        public int Quantity {get; set;}

        public double Value { get; set; }

        public int Category_id {get; set;}

        public Category? Category {get; set;}

        public ICollection<Moviment>? Moviments {get; set;}
    }

        
}