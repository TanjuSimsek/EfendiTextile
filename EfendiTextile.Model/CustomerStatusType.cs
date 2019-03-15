using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Model
{
    public enum CustomerStatusType
    {
        [Display(Name = "Müşteri")]
        Customer =1, 
        [Display(Name = "Müşteri Değil")]
        NonCustomer =2
    }
}
