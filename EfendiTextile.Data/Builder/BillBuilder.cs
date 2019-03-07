using EfendiTextile.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Data.Builder
{
   public class BillBuilder
    {
        public BillBuilder(EntityTypeConfiguration<Bill> entity) {

            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Description).IsRequired().HasMaxLength(400);
            entity.HasOptional(e => e.Customer).WithMany(c => c.Bills).HasForeignKey(p => p.CustomerId);


        }
    }
}
