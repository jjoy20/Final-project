using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBDcase.Models
{
    public class Client
    {
        public Client()
        {
            Projects = new HashSet<Project>();
        }
        public int ID { get; set; }

        [Display(Name = "Client Name")]
        [Required(ErrorMessage = "You cannot leave client name blank.")]
        [StringLength(50, ErrorMessage = "Client name cannot be more than 50 characters long.")]
        public string ClientName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "You cannot leave the address blank.")]
        [StringLength(255, ErrorMessage = "Address cannot be more than 255 characters long.")]
        public string Address { get; set; }

        [Display(Name = "Contact")]
        [Required(ErrorMessage = "You cannot leave Contact blank.")]
        [StringLength(255, ErrorMessage = "Contact cannot be more than 255 characters long.")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression("^\\d{10}$", ErrorMessage = "Please enter a valid 10-digit phone number (no spaces).")]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:(###) ###-####}", ApplyFormatInEditMode = false)]
        public Int64 Phone { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
