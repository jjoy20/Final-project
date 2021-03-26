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
        public Material()
        {
            Inventories = new HashSet<Inventory>();
        }
        public int ID { get; set; }

        [Display(Name = "Code")]
        [Required(ErrorMessage = "You cannot leave code blank.")]
        [StringLength(50, ErrorMessage = "Code cannot be more than 50 characters long.")]
        public string Code { get; set; }

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


        [Required(ErrorMessage = "You must select a Category.")]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        public Category Category { get; set; }

        public ICollection<Inventory> Inventories { get; set; }

    }
}
