using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Model
{
  public  class Region:BaseEntity
    {
        public Region() {
            Customers = new HashSet<Customer>();
            Districts = new HashSet<District>();
        }
        public string RegionName { get; set; }
        public Guid CityId { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<District> Districts { get; set; }
    }
}
