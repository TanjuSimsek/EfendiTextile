using EfendiTextile.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Data.Builder
{
   public class CustomerBuilder
    {
        public CustomerBuilder(EntityTypeConfiguration<Customer> entity) {

            entity.Property(e => e.CustomerName).IsRequired().HasMaxLength(200);
            entity.Property(e => e.CustomerSurname).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Address).IsRequired().HasMaxLength(200);
            entity.HasRequired(e => e.Region).WithMany(c => c.Customers).HasForeignKey(p => p.RegionId);

        }
    }
}
