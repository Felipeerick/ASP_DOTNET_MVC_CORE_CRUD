using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projeto_web.Models;

namespace projeto_web.Map
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category>builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(n => n.Name).HasMaxLength(40).IsRequired();
            builder.HasMany(p => p.Products).WithOne(c => c.Category);

            builder.ToTable("Category");
        }       
    }
}