using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chinook.Model
{

    [Table("Customer")]
    public partial class Customer
    {
        public Customer()
        {
            Invoice = new HashSet<Invoice>();
        }

        public int CustomerId { get; set; }

        [Required(ErrorMessage ="Este campo es requerido")]
        [StringLength(40, ErrorMessage = "Este campo requiere como maximo 40 caracteres. ")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Este campo es requerido")]
        [StringLength(40, ErrorMessage = "Este campo requiere como maximo 40 caracteres. ")]
        public string LastName { get; set; }

        [StringLength(80, ErrorMessage = "Este campo requiere como maximo 80 caracteres. ")]
        public string Company { get; set; }

        [StringLength(70, ErrorMessage = "Este campo requiere como maximo 70 caracteres. ")]
        public string Address { get; set; }

        [StringLength(40, ErrorMessage = "Este campo requiere como maximo 40 caracteres. ")]
        public string City { get; set; }

        [StringLength(40)]
        public string State { get; set; }

        [StringLength(40)]
        public string Country { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(24)]
        public string Fax { get; set; }

        [Required(ErrorMessage ="Este campo es requerido")]
        [StringLength(60, ErrorMessage = "Este campo requiere como maximo 60 caracteres. ")]

        public string Email { get; set; }

        public int? SupportRepId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
