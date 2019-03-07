using EfendiTextile.Data.Builder;
using EfendiTextile.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
             : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new BillBuilder(modelBuilder.Entity<Bill>());
            new CategoryBuilder(modelBuilder.Entity<Category>());
            new CustomerBuilder(modelBuilder.Entity<Customer>());
            new OfferBuilder(modelBuilder.Entity<Offer>());
            new OrderBuilder(modelBuilder.Entity<Order>());
            new ProductBuilder(modelBuilder.Entity<Product>());
            new RegionBuilder(modelBuilder.Entity<Region>());


        }

    }
}
