﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Model
{
   public class Category:BaseEntity
    {
        public Category() {

            Products = new HashSet<Product>();
        }
        [Display(Name = "Kategori Adı")]
        public string CategoryName { get; set; }
        [Display(Name = "Kategori Açıklama")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Kategori Fotoğraf")]
        public string Photo { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
