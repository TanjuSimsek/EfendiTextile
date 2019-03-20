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

           
            Products = new HashSet<Product>();
          
        }
        [Display(Name ="Teklif Açıklama")]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Teklif Fiyat")]
        public float OfferPrice { get; set; }
        [Display(Name = "Müşteri")]
        public Guid? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Product> Products { get; set; }
       


    }
}
