using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAll.Models
{
    public class EventEquipment
    {
        public int EventID { get; set; }
        public Event Event { get; set; }
        public int EquipmentID { get; set; }
        public Equipment Equipment { get; set; }

    }
}
