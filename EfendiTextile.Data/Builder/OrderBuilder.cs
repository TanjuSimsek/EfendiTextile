using EfendiTextile.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Data.Builder
{
    public class OrderBuilder
    {
        public OrderBuilder(EntityTypeConfiguration<Order> entity) {

            entity.Property(p => p.Quantity).IsRequired();
            entity.Property(p => p.UnitPrice).IsRequired();

        }
    }
}
