using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "İl Adı")]
        public string CityName { get; set; }
        [Display(Name = "İl Adı")]
        public Guid? CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Region> Regions { get; set; }

    }
}
