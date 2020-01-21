using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAll.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int EquipmentID {get;set;}
        public Equipment Equipment { get; set; }
    }
}
