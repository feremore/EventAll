using EventAll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAll.ViewModels
{
    public class ViewEquipmentViewModel
    {
        public Equipment Equipment { get; set; }
        public IList<Item> Items { get; set; }
        public IList<Equipment> Equipments { get; set; }
        public IList<EventEquipment> Events { get; set; }
       
    }
}
