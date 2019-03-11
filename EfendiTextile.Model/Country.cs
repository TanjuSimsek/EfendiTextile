using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Model
{
    public class Country:BaseEntity
    {
        public Country()
        {
            Customers = new HashSet<Customer>();
            Cities = new HashSet<City>();
        }
        public string CountryName { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<City> Cities { get; set; }

    }
}
