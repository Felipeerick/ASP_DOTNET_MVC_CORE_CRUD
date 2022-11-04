using projeto_web.Data;

namespace projeto_web.Helpers
{
    public class Helpers
    {
        private readonly ContextMysql _context;

        public Helpers(ContextMysql value)
        {
            _context = value;
        }  

        public void ValidateProductQuantity(string NameMoviment,int Quantity ,int Product_id)
        {
            var product = _context.Products.Find(Product_id);

            if(NameMoviment == "ENTRADA")
            {
                product.Quantity += Quantity;
                    
                _context.Products.Update(product);
            }
            else if(NameMoviment == "SAIDA")
            {
                product.Quantity -= Quantity;
                
                _context.Products.Update(product);
            }  
        } 

    }
}