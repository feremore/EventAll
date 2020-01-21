using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAll.Models
{
    public class Equipment
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IList<EventEquipment> EventEquipments { get; set; }
        public IList<Item> Items { get; set; }
    }
}
