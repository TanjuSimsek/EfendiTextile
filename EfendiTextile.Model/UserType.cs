using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Model
{
    public enum UserType
    {
        [Display(Name ="Yönetici")]
        Admin=1,
        [Display(Name = "Kullanıcı")]
        User =2
    }
}
