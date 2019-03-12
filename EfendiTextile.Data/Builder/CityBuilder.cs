using EfendiTextile.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Data.Builder
{
  public  class CityBuilder
    {
        public CityBuilder(EntityTypeConfiguration<City> entity)
        {

            entity.Property(p => p.CityName).IsRequired().HasMaxLength(100);
            entity.HasRequired(p => p.Country).WithMany(p => p.Cities).HasForeignKey(f => f.CountryId);

        }

    }
}
