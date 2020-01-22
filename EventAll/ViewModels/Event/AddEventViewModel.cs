using EventAll.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventAll.ViewModels.Event
{
    public class AddEventViewModel
    {
        [Required]
        [Display(Name ="Name of Event")]
        public string Name { get; set; }
        [Required]
        [Display(Name="Date of Event")]
        public string Date { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed for")]
        [Display(Name="Budget for Event")]
        public double Budget { get; set; }
        [Required]
        [Display(Name = "Venue")]
        public int VenueID { get; set; }
        public List<SelectListItem> Venues { get; set; }
        public string Description { get; set; }
        
        public AddEventViewModel(IEnumerable<Venue> venues)
        {
            if (venues != null)
            {
                Venues = new List<SelectListItem>();
                foreach (var ven in venues)
                {
                    Venues.Add(new SelectListItem
                    {
                        Value = ven.ID.ToString(),
                        Text = ven.Name
                    });

                }
            }
        }
        public AddEventViewModel()
        {

        }

    }
}
