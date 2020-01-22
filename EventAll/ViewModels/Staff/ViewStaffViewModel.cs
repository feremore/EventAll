using EventAll.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventAll.ViewModels
{
    public class ViewStaffViewModel
    {
        public Staff Staff { get; set; }
        [MinLength(1)]
        public string Job { get; set; }        
        public IList<EventStaff> Events { get; set; }
    }
}
