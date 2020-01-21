using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAll.Models
{
    public class Venue
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public int Capacity { get; set; }
        public double Price { get; set; }
        public IList<EventVenue> Events { get; set; }

    }
}
