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
