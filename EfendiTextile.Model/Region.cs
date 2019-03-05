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
        }
        [Display(Name ="İlçe")]
        public string City { get; set; }
        [Display(Name = "İl")]
        public string Country { get; set; }
        [Display(Name = "Mahalle")]
        public string District { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
