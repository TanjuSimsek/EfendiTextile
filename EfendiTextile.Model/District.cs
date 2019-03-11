using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Model
{
   public class District:BaseEntity
    {
        public District()
        {
            Customers = new HashSet<Customer>();
        }
        public string DistrictName { get; set; }
        public Guid RegionId { get; set; }
        public virtual Region Region { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }

    }
}
