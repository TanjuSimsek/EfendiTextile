using EfendiTextile.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Data.Builder
{
  public  class CountryBuilder
    {
        public CountryBuilder(EntityTypeConfiguration<Country> entity)
        {

            entity.Property(p => p.CountryName).IsRequired().HasMaxLength(100);
          

        }

    }
}
