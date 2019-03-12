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

            entity.Property(p => p.RegionName).IsRequired().HasMaxLength(100);
            entity.HasRequired(p => p.City).WithMany(p => p.Regions).HasForeignKey(f => f.CityId);

        }
    }
}
