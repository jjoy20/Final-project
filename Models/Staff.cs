using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBDcase.Models
{
    public class Staff
    {
        public int ID { get; set; }

        [Display(Name = "Position Name")]
        [Required(ErrorMessage = "You cannot leave position name blank.")]
        [StringLength(50, ErrorMessage = "Position name cannot be more than 50 characters long.")]
        public string PositionName { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(19,2)")]
        [Range(0, 99999999999999999.99, ErrorMessage = "Invalid Salary")]
        public decimal Salary { get; set; }


        [Display(Name = "Hours")]
        [Required(ErrorMessage = "Hours is required")]
        public int Hours { get; set; }


        [Required(ErrorMessage = "You must select a BID.")]
        [Display(Name = "BID")]
        public int BidID { get; set; }
        public Bid Bid { get; set; }

        [Required(ErrorMessage = "You must select a LaborID.")]
        [Display(Name = "LaborID")]
        public int LaborID { get; set; }      

        public Labor Labor { get; set; }
    }
}
