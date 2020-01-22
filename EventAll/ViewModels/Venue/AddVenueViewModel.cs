using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventAll.ViewModels
{
    public class AddVenueViewModel
    {
        [Required]
        [Display(Name = "Venue Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Venue Capacity")]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed for")]        
        public int Capacity { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed for")]
        [Display(Name = "Venue Price")]
        public double Price { get; set; }
        public AddVenueViewModel()
        {

        }
    }
}
