using EventAll.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventAll.ViewModels
{
    public class AddItemEquipmentViewModel
    {
             
        [Required]
        [Display(Name = "Equipment Type")]
        public int EquipmentID { get; set; }
        public int NumItems { get; set; }
        public int TotalItems { get; set; }

        public List<SelectListItem> Equipments { get; set; }


        public AddItemEquipmentViewModel(IEnumerable<Equipment> equipments)
        {
            if (equipments != null)
            {
                Equipments = new List<SelectListItem>();
                foreach (var type in equipments)
                {
                    Equipments.Add(new SelectListItem
                    {
                        Value = type.ID.ToString(),
                        Text = type.Name
                    });

                }
            }

        }
        public AddItemEquipmentViewModel()
        {


        }
    }
}
