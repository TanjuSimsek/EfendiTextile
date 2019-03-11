using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Model
{
   public class City:BaseEntity
    {
        public City()
        {
            Customers = new HashSet<Customer>();
            Regions = new HashSet<Region>();
        }
        public string CityName { get; set; }
        public Guid CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Region> Regions { get; set; }

    }
}
