using EventAll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAll.ViewModels
{
    public class ViewEventViewModel
    {
        public Models.Event Event { get; set; }
        public IList<EventStaff> Staffs { get; set; } 
        public IList<EventEquipment> Equipments { get; set; }
        
    }
}
