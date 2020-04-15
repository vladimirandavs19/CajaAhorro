using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CajaAhorro.Web.Data.Entities
{
    public class Client : IEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "First Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(10)]
        public string DNI { get; set; }

        [Required]
        [MaxLength(500)]
        public string Address { get; set; }

        [Required]
        [MaxLength(100)]
        public string Mail { get; set; }

        public DateTime Birthday { get; set; }

        [Required]
        [MaxLength(11)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(12)]
        public string CellPhone { get; set; }

        [Required]
        [MaxLength(12)]
        public string WorkPhone { get; set; }

        public int Gender { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float DebitValue { get; set; }

        [Required]
        [MaxLength(30)]
        public string AccountNumber { get; set; }

        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Date Modified")]
        public DateTime DateModified { get; set; }

        public bool Deleted { get; set; }

        public Bank Bank { get; set; }

        public Ocupation Ocupation { get; set; }
    }
}
