using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBDcase.Models
{
    public class Inventory
    {
         public int ID { get; set; }

        [Display(Name = "Code")]
        [Required(ErrorMessage = "You cannot leave code blank.")]
        [StringLength(10, ErrorMessage = "Code cannot be more than 10 characters long.")]
        public string Code { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "You cannot leave description blank.")]
        [StringLength(255, ErrorMessage = "Description cannot be more than 255 characters long.")]
        public string Description { get; set; }

        [Display(Name = "Size")]
        [Required(ErrorMessage = "You cannot leave size blank.")]
        [StringLength(10, ErrorMessage = "Size cannot be more than 10 characters long.")]
        public string Size { get; set; }

        [Required(ErrorMessage = "You must select a Bid.")]
        [Display(Name = "Bid")]
        public int BidID { get; set; }

        public Bid Bid { get; set; }

        [Required(ErrorMessage = "You must select a Material.")]
        [Display(Name = "Material")]
        public int MaterialID { get; set; }

        public Material Material { get; set; }

    }
}
