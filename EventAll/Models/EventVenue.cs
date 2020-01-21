using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAll.Models
{
    public class EventVenue
    {
        public int EventID { get; set; }
        public Event Event { get; set; }

        public int VenueID { get; set; }
        public Venue Venue { get; set; }
    }
}
