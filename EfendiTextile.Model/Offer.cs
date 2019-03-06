using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Model
{
 public class Offer:BaseEntity
    {
        public Offer() {

            Customers = new HashSet<Customer>();
            Products = new HashSet<Product>();
        }
        [Display(Name ="Teklif Açıklama")]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Teklif")]
        public float OfferPrice { get; set; }
        public virtual  ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Product> Products { get; set; }


    }
}
