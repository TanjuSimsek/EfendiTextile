using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Model
{
   public class Order:BaseEntity
    {
        public Order() {
            Products = new HashSet<Product>();

        }
        [Display(Name ="Birim Fiyatı")]
        [DataType(DataType.Currency)]
        public float UnitPrice { get; set; }
        [Display(Name = "Adet")]
        public int Quantity { get; set; }


        public virtual ICollection<Product> Products { get; set; }


    }
}
