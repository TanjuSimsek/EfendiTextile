using EfendiTextile.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Data.Builder
{
   public class DistrictBuilder
    {
        public DistrictBuilder(EntityTypeConfiguration<District> entity)
        {

            entity.Property(p => p.DistrictName).IsRequired().HasMaxLength(100);
            entity.HasRequired(p => p.Region).WithMany(p => p.Districts).HasForeignKey(f => f.RegionId);

        }

    }
}
