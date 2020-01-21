using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventAll.ViewModels
{
    public class AddStaffViewModel
    {
        [Required]
        [Display(Name = "Staff Name")]
        public string Name { get; set; }
        
       
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed for")]
        [Display(Name = "Staff Wage")]
        public double Wage { get; set; }
        [Required]
        [Display(Name = "Staff Skill")]
        public string Job { get; set; }
        public List<string> Skills { get; set; }
        public AddStaffViewModel()
        {

        }
    }
}
