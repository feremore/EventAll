using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAll.Models
{
    public class Event
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public double Budget { get; set; }
        public double TotalCost { get; set; }
        public double MiscCost { get; set; }
        public int VenueID { get; set; }
        public Venue Venue { get; set; }
        public IList<EventStaff> Staffs { get; set; }
        public IList<EventEquipment> Equipments { get; set; }

        public Event()
        {
            
            this.TotalCost = 0.0;
            this.MiscCost = 0.0;
            

        }

        //public Event()
        //{ 
        
        //}
    }
}
