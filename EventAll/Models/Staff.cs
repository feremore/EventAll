using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAll.Models
{
    public class Staff
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<string> Skills { get; set; }
        public double Wage { get; set; }
        public IList<EventStaff> Events { get; set; }
    }
}
