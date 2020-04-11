using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CajaAhorro.Web.Data.Entities
{
    public class Company : IEntity
    {
        public int Id { get; set; }

        [MaxLength(200, ErrorMessage = "The field {0} must be {1} characters")]
        [Required(ErrorMessage = "{0} is required", AllowEmptyStrings = false)]
        public string Name { get; set; }

        [MaxLength(20, ErrorMessage = "The field {0} must be {1} characters")]
        [Required(ErrorMessage = "{0} is required", AllowEmptyStrings = false)]
        public string DNI { get; set; }

        public string Address { get; set; }

        [MaxLength(11, ErrorMessage = "The field {0} must be {1} characters")]
        [Required(ErrorMessage = "{0} is required", AllowEmptyStrings = false)]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }

        public string CellPhone { get; set; }

        [Display(Name = "Initial Date")]
        public DateTime InitialDate { get; set; }

        [Display(Name = "Modify Date")]
        public DateTime ModifyDate { get; set; }
    }
}
