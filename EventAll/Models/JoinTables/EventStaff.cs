using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAll.Models
{
    public class EventStaff
    {
        public int EventID { get; set; }
        public Event Event { get; set; }
        public int StaffID { get; set; }
        public Staff Staff { get; set; }
        
       
    }
}
