using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projeto_web.Models;

namespace projeto_web.Map
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product>builder){
            builder.HasKey(k => k.Id);
            builder.Property(n => n.Name).HasMaxLength(40).IsRequired();
            builder.Property(q => q.Quantity).IsRequired();
            builder.Property(v => v.Value).IsRequired();

            builder.HasOne(c => c.Category).WithMany(p =>p.Products).HasForeignKey(k => k.Category_id).IsRequired();
            builder.HasMany(m => m.Moviments).WithOne(p => p.Product);

            builder.ToTable("Products");
        }
    }
}