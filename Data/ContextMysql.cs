using Microsoft.EntityFrameworkCore;
using projeto_web.Models;
using projeto_web.Map;
namespace projeto_web.Data
{
    public class ContextMysql : DbContext
    {
        public DbSet<Product>? Products {get; set;}

        public DbSet<Moviment>? Moviments {get; set;}

        public DbSet<Category>? Categories {get; set;}

        public ContextMysql(DbContextOptions<ContextMysql>options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new MovimentMap());
            builder.ApplyConfiguration(new CategoryMap());
        }
    }
}