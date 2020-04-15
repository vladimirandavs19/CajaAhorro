using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CajaAhorro.Web.Data.Entities
{
    public class Ocupation : IEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        public string Name { get; set; }

        [Display(Name = "Date Created")]
        public DateTime DateCreate { get; set; }

        [Display(Name = "Date Modified")]
        public DateTime DateModified { get; set; }

        public bool Deleted { get; set; }
    }
}
