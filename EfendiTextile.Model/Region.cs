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
        [Display(Name ="İlçe Adı")]
        public string RegionName { get; set; }
        [Display(Name = "İlçe Adı")]
        public Guid CityId { get; set; }
        
        public virtual City City { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
       
    }
}
