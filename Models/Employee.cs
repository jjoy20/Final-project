using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBDcase.Models
{
    public class Employee
    {
        public Employee()
        {
            Designers = new HashSet<Bid>();
            Sales = new HashSet<Bid>();
        }

        public int ID { get; set; }

        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "You cannot leave the first name blank.")]
        [StringLength(50, ErrorMessage = "First name cannot be more than 50 characters long.")]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        [Required(ErrorMessage = "You cannot leave the last name blank.")]
        [StringLength(50, ErrorMessage = "Last name cannot be more than 50 characters long.")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Email address is required.")]
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        public string eMail { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression("^\\d{10}$", ErrorMessage = "Please enter a valid 10-digit phone number (no spaces).")]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:(###) ###-####}", ApplyFormatInEditMode = false)]
        public Int64 Phone { get; set; }

        [Required(ErrorMessage = "Please enter your LaborID")]
        [Display(Name ="LaborID")]
        public int LaborID { get; set; }
        public Labor Labor { get; set; }


        [InverseProperty("Designer")]
        public ICollection<Bid> Designers { get; set; }

        [InverseProperty("Sales")]
        public ICollection<Bid> Sales { get; set; }


    }
}
