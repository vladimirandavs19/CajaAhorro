using CajaAhorro.Web.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CajaAhorro.Web.Models
{
    public class BankCompanyViewModel : BankCompany
    {
        public SelectList BankSelectList { get; set; }

        public SelectList CompanySelectList { get; set; }

        public SelectList TypeAccountList { get; set; }

        [Display(Name ="Type Account Name")]
        public string TypeAccountName { get; set; }

        [Display(Name = "Bank")]
        [Required]
        public int BankId { get; set; }

        [Display(Name = "Company")]
        [Required]
        public int CompanyId { get; set; }
    }
}
