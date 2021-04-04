using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBDcase.Models
{
    public class Bid
    {
        public Bid()
        {
            Staffs = new HashSet<Staff>();
            Inventories = new HashSet<Inventory>();
            BidEmployees = new HashSet<BidEmployees>();
        }

        public int ID { get; set; }

        [Display(Name = "Creation Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BidDate { get; set; }

        [Display(Name = "Estimated Start Date")]
        [Required(ErrorMessage = "EstBeginDate is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EstBeginDate { get; set; }

        [Display(Name = "Estimated Completion Date")]
        [Required(ErrorMessage = "EstComplDate is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EstComplDate { get; set; }

        [Display(Name = "Budget")]
        [Required(ErrorMessage = "BidAmount is required.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(19,2)")]
        [Range(0, 99999999999999999.99, ErrorMessage = "Invalid Bid Amount")]
        public decimal BidAmount { get; set; }

        [Display(Name = "Time (hours)")]
        [Required(ErrorMessage = "BidHours is required.")]
        [Range(0, 999, ErrorMessage = "Invalid Bid Hours!")]
        public int BidHours { get; set; }


        [Required(ErrorMessage = "ApprovalNBD is required.")]
        [Display(Name = "Internal Approval")]
        public bool ApprovalbyNBD { get; set; }

        [Required(ErrorMessage = "ApprovalClient is required.")]
        [Display(Name = "Approval By Client")]
        public bool ApprovalbyClient { get; set; }

        public string bidlist
        {
            get
            {
                return this.ID.ToString() + ". Bid start from " + this.EstBeginDate.ToString("d")+" to "+this.EstComplDate.ToString("d") + " with budget of"+this.BidAmount.ToString("c");
            }
        }
        [Required(ErrorMessage = "You must select a ProjectID.")]
        [Display(Name = "Project")]
        public int ProjectID { get; set; }
        public Project Project { get; set; }

        [Required(ErrorMessage = "You must select a Designer EmployeeID.")]
        [Display(Name = "Designer")]
        public int DesignerID { get; set; }
        public Employee Designer { get; set; }

        [Required(ErrorMessage = "You must select a Sales EmployeeID.")]
        [Display(Name = "Sales")]
        public int SalesID { get; set; }
        public Employee Sales { get; set; }


        [Display(Name = "Staffs")]
        public ICollection<Staff> Staffs { get; set; }

        [Display(Name = "Inventories")]
        public ICollection<Inventory> Inventories { get; set; }
        [Display(Name = "BidEmployees")]
        public ICollection<BidEmployees> BidEmployees{ get; set; }
    }
}
