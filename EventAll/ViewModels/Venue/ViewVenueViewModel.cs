using EventAll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAll.ViewModels
{
    public class ViewVenueViewModel
    {
        public Venue Venue { get; set; }
        public IList<EventVenue> Events { get; set; }
    }
}
