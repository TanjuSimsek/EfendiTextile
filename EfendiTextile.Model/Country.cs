using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Ülke Adı")]
        public string CountryName { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<City> Cities { get; set; }

    }
}
