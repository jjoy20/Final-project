using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBDcase.Models
{
    public class Category
    {
        public Category()
        {
            Materials = new HashSet<Material>();
        }
        public int ID { get; set; }

        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "You cannot leave category name blank.")]
        [StringLength(50, ErrorMessage = "Category name cannot be more than 50 characters long.")]
        public string CategoryName { get; set; }

        public ICollection<Material> Materials { get; set; }
    }
}
