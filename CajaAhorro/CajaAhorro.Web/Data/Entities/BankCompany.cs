using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CajaAhorro.Web.Data.Entities
{
    public class BankCompany : IEntity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Account Number")]
        [DisplayFormat(DataFormatString = "{0:0}", ConvertEmptyStringToNull = true)]
        public int AccountNumber { get; set; }

        [Display(Name = "Account Type")]
        public int AccountType { get; set; }

        [Display(Name = "Check Number")]
        public Nullable<int> CheckNumber { get; set; }

        public Company Company { get; set; }

        public Bank Bank { get; set; }

        [Display(Name = "Date Created")]
        public DateTime DateCreate { get; set; }

        [Display(Name = "Date Modified")]
        public DateTime DateModify { get; set; }

        public bool Deleted { get; set; }
    }
}
