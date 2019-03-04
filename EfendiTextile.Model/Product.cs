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
     
        [Display(Name ="Urün Adı")]
        public string ProductName { get; set; }
        [Display(Name ="Miktar")]
        public int QuantityPerUnit { get; set; }
        [Display(Name = "Fiyat")]
        [DataType(DataType.Currency)]
        public float UnitPrice { get; set; }
        [Display(Name = "Stok Durumu")]
        public bool UnıtsInStock { get; set; }
        public Guid? CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
