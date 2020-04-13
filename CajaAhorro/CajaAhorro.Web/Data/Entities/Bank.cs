using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CajaAhorro.Web.Data.Entities
{
    public class Bank : IEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Bank Name")]
        public string Name { get; set; }

        [Display(Name = "Create Date")]
        public Nullable<DateTime> CreateDate { get; set; }

        [Display(Name = "Modify Date")]
        public Nullable<DateTime> ModifyDate { get; set; }
    }
}
