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
        [Display(Name ="Satış Fiyatı")]
        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }
        [Display(Name = "İstenilen Tarih")]
        public DateTime RequiredDate { get{ return DateTime.Now; } }
        [Display(Name = "Miktar")]
        public int Quantity { get; set; }
        [Display(Name = "Tutar")]
        public decimal Amount { get { return UnitPrice * Quantity; }  }


        public virtual ICollection<Product> Products { get; set; }


    }
}
