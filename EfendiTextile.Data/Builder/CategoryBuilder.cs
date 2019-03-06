using EfendiTextile.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Data.Builder
{
   public class CategoryBuilder
    {
        public CategoryBuilder(EntityTypeConfiguration<Category> entity) {

            entity.Property(p => p.Description).IsRequired().HasMaxLength(200);
            entity.Property(p => p.CategoryName).IsRequired().HasMaxLength(200);

        }
    }
}
