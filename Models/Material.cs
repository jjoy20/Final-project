using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBDcase.Models
{
    public class Material
    {
        public int ID { get; set; }

        [Display(Name = "Type")]
        [Required(ErrorMessage = "You cannot leave type blank.")]
        [StringLength(50, ErrorMessage = "Type cannot be more than 50 characters long.")]
        public string Type { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "You cannot leave quantity blank.")]
        public int Quantity { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "You cannot leave description blank.")]
        [StringLength(255, ErrorMessage = "Description cannot be more than 255 characters long.")]
        public string Description { get; set; }

        [Display(Name = "Size")]
        [Required(ErrorMessage = "You cannot leave size blank.")]
        [StringLength(10, ErrorMessage = "Size cannot be more than 10 characters long.")]
        public string Size { get; set; }

        [Required(ErrorMessage = "Unit price is required.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(19,2)")]
        [Range(0, 99999999999999999.99, ErrorMessage = "Invalid UnitPrice.")]
        public decimal UnitPrice { get; set; }


        [Required(ErrorMessage = "You must select a Inventory.")]
        [Display(Name = "Inventory")]
        public int InventoryID { get; set; }

        public Inventory Inventory { get; set; }
    }
}
