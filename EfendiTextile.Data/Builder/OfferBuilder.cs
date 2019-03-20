using EfendiTextile.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Data.Builder
{
  public  class OfferBuilder
    {
        public OfferBuilder(EntityTypeConfiguration<Offer> entity) {


            entity.Property(p => p.Description).IsRequired().HasMaxLength(200);
            entity.Property(p => p.OfferPrice).IsRequired();
            entity.HasRequired(p => p.Customer).WithMany(p => p.Offers).HasForeignKey(f => f.CustomerId);
            entity.HasMany(p => p.Products)
             .WithMany(s => s.Offers).Map(cs =>
             {
                 cs.MapLeftKey("ProductId");
                 cs.MapRightKey("OfferId");
                 cs.ToTable("ProductOfOffer");
             });

        }

    }
}
