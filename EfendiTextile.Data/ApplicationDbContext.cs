using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() : base("name=DefaultConnection")
        {
           

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
