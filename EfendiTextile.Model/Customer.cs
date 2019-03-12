using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfendiTextile.Model
{
   public class Customer:BaseEntity
    {
        public Customer() {

            Bills = new HashSet<Bill>();
            Offers = new HashSet<Offer>();
        }


        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Borç")]
        [DataType(DataType.Currency)]
        public float Debt { get; set; }
        [Display(Name = "Alacak")]
        [DataType(DataType.Currency)]
        public float Demand { get; set; }
        [Display(Name = "Bakiye")]
        [DataType(DataType.Currency)]
        public float Balance { get; set; }
       // public Guid CustomerId { get; set; }
        [Display(Name = "Müşteri Adı")]
        public string CustomerName { get; set; }
        [Display(Name = "Müşteri Soyadı")]
        public string CustomerSurname { get; set; }
        [Display(Name = "Müşteri Telefon")]
        public string Phone { get; set; }
        [Display(Name = "Müşteri Email")]
        [EmailAddress(ErrorMessage ="E-Mail Formatında Olmalı")]
        public string Email { get; set; }
        [Display(Name = "Müşteri Adres")]
        public string Address { get; set; }
        public Guid? RegionId { get; set; }
        public virtual Region Region { get; set; }

        public Guid? CountryId { get; set; }
        public virtual Country Country { get; set; }
        public Guid? CityId { get; set; }
        public virtual City City { get; set; }
        public Guid? DistrictId { get; set; }
        public virtual District District { get; set; }

        public  CustomerStatusType CustomerStatusType{ get; set; }
        public virtual  ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }

    }
}
