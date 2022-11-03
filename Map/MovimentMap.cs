using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projeto_web.Models;


namespace projeto_web.Map
{
    public class MovimentMap : IEntityTypeConfiguration<Moviment>
    {
        public void Configure(EntityTypeBuilder<Moviment>builder){
            builder.HasKey(k => k.Id);
            builder.Property(q => q.Quantity).IsRequired();
            builder.Property(d => d.Description).IsRequired();
            builder.Property(dt => dt.DateMoviment).IsRequired();

            builder.HasOne(p => p.Product).WithMany(m => m.Moviments).HasForeignKey(pi => pi.Product_id);
            builder.ToTable("Moviments");
        }
    }
}