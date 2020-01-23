using EventAll.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAll.ViewModels
{
    public class ViewEventViewModel
    {
        public Models.Event Event { get; set; }
        public Venue Venue { get; set; }
        public IList<Models.Event> Events { get; set; }
        public IList<EventStaff> Staffs { get; set; } 
        public IList<EventEquipment> Equipments { get; set; }   
        public IList<Item> Items { get; set; }
        public IList<Venue> Venues { get; set; }
        public List<SelectListItem> StaffList { get; set; }
        public int StaffID { get; set; }
        public List<SelectListItem> EquipmentList { get; set; }
        public int EquipmentID { get; set; }
        public string Description { get; set; }

        public ViewEventViewModel(IEnumerable<Equipment> equipments, IEnumerable<Staff> staffs)
        {
            if (equipments != null)
            {
                EquipmentList = new List<SelectListItem>();
                foreach (var equip in equipments)
                {
                    
                    EquipmentList.Add(new SelectListItem
                    {
                        Value = equip.ID.ToString(),
                        Text = equip.Name
                    });

                }
            }
            if (staffs != null)
            {
                StaffList = new List<SelectListItem>();
                foreach (var staff in staffs)
                {
                    EquipmentList.Add(new SelectListItem
                    {
                        Value = staff.ID.ToString(),
                        Text = staff.Name
                    });

                }
            }
        }
       
       public ViewEventViewModel()
        {

        }

    }
}
