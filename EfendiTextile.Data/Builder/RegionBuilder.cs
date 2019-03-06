using EfendiTextile.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Data.Builder
{
   public class RegionBuilder
    {
        public RegionBuilder(EntityTypeConfiguration<Region> entity) {

            entity.Property(e => e.City).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Country).IsRequired().HasMaxLength(100);
            entity.Property(e => e.City).IsRequired().HasMaxLength(100);
            entity.Property(e => e.District).IsRequired().HasMaxLength(100);


        }
    }
}
