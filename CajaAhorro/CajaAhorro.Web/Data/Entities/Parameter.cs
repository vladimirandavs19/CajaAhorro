using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CajaAhorro.Web.Data.Entities
{
    public class Parameter : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Type")]
        public int ParameterType { get; set; }

        [Required]
        [Display(Name = "Type Name (Description)")]
        [MaxLength(50)]
        public String TypeName { get; set; }

        [Required]
        [Display(Name = "Value (String)")]
        [MaxLength(100)]
        public String StringValue { get; set; }

        [Display(Name = "Value (Int)")]
        public Nullable<int> IntValue { get; set; }

        [Display(Name = "Value (Bool)")]
        public Nullable<Boolean> BoolValue { get; set; }

        [Display(Name = "Value (Number)")]
        public Nullable<float> NumberValue { get; set; }
    }
}
