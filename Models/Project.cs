using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBDcase.Models
{
    public class Project
    {
        public Project()
        {
            Bids = new HashSet<Bid>();
        }

        public int ID { get; set; }

        [Display(Name = "Project Name")]
        [Required(ErrorMessage = "You cannot leave project name blank.")]
        [StringLength(50, ErrorMessage = "Project name cannot be more than 50 characters long.")]
        public string ProjectName { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BeginDate { get; set; }

        [Display(Name = "Completion Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CompleteDate { get; set; }

        [Display(Name = "Project Site")]
        [Required(ErrorMessage = "You cannot leave project site blank.")]
        [StringLength(255, ErrorMessage = "Project site cannot be more than 255 characters long.")]
        public string ProjectSite { get; set; }

        [Required(ErrorMessage = "You must select a client.")]
        [Display(Name = "Client")]
        public int ClientID { get; set; }
        public Client Client { get; set; }

        public ICollection<Bid> Bids { get; set; }
    }
}
