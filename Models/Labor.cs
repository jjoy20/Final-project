using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBDcase.Models
{
    public class Labor
    {
        public int ID { get; set; }

        [Display(Name = "Labor Type")]
        [Required(ErrorMessage = "You cannot leave labor type blank.")]
        [StringLength(50, ErrorMessage = "Labor type cannot be more than 50 characters long.")]
        public string LaborType { get; set; }


        [Required(ErrorMessage = "Labor price is required.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(19,2)")]
        [Range(0, 99999999999999999.99, ErrorMessage = "Invalid labor price")]
        public decimal LaborPrice { get; set; }

        [Required(ErrorMessage = "Labor cost is required.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(19,2)")]
        [Range(0, 99999999999999999.99, ErrorMessage = "Invalid labor cost.")]
        public decimal LaborCost { get; set; }

        [Required(ErrorMessage = "You must select a Staff ID")]
        [Display(Name = "Position Name")]
        public int StaffID { get; set; }

        public Staff Staff { get; set; }
    }
}
