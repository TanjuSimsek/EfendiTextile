using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Model
{
   public class ApplicationUser
    {
        [Display(Name = "Resim")]
        public string Photo { get; set; }
        [Display(Name = "Ad-Soyad")]
        public string FullName { get; set; }

    }
}
