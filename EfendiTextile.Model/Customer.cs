using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Model
{
   public class Customer:BaseEntity
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
