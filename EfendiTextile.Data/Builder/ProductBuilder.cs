using EfendiTextile.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Data.Builder
{
   public  class ProductBuilder
    {
        public ProductBuilder(EntityTypeConfiguration<Product> entity) {

            entity.Property(p => p.ProductName).IsRequired().HasMaxLength(200);
            entity.Property(p => p.QuantityPerUnit).IsRequired();
            entity.Property(p => p.BuyyingPrice).IsRequired();
            entity.HasRequired(p => p.Category).WithMany(p => p.Products).HasForeignKey(f => f.CategoryId);
            entity.HasMany<Order>(p=>p.Orders)
                .WithMany(s => s.Products).Map(cs =>
                {
                    cs.MapLeftKey("ProductRefId");
                    cs.MapRightKey("OrderRefId");
                    cs.ToTable("ProductIOfOrder");
                });



        }
    }
}
