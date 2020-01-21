using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventAll.ViewModels
{
    public class AddEquipmentViewModel
    {
        [Required]
        [Display(Name = "Equipment Name")]
        public string Name { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed for")]
        [Display(Name ="Equipment Price")]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Staff Skill")]
        public string Job { get; set; }
    }
}
