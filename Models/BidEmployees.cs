using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBDcase.Models
{
    public class BidEmployees
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "You must select a Bid.")]
        [Display(Name = "Bid")]
        public int BidID { get; set; }

        public Bid Bid { get; set; }
       
        [Required(ErrorMessage = "You must select a Employee.")]
        [Display(Name = "Employee")]
        public int EmployeeID { get; set; }

        public Employee Employee { get; set; }
    }
}
