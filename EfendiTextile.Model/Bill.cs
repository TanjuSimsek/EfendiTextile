using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Model
{
    public class Bill:BaseEntity
    {
        public int BillId { get; set; }
        [Display(Name="Fatura")]
        public string Title { get; set; }
        [Display(Name ="Fatura Açıklama")]
        public string Description { get; set; }
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
       
        

    }
}
