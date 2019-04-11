using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Model
{
    public class Product:BaseEntity
    {
        public Product() {

            Orders = new HashSet<Order>();
            Offers = new HashSet<Offer>();
        }
        [Display(Name ="Ürün Adı")]
        public string ProductName { get; set; }
        [Display(Name ="Miktar")]
        public int QuantityPerUnit { get; set; }
        [Display(Name = "Alış Fiyatı")]
        [DataType(DataType.Currency)]
        public float BuyyingPrice { get; set; }
        [Display(Name = "Stok Durumu")]
        public bool UnıtsInStock { get; set; }
        [Display(Name = "KategoriId")]
        public Guid? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }

    }
}
