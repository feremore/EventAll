using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventAll.Data;
using EventAll.Models;
using EventAll.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventAll.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly ApplicationDbContext context;

        public EquipmentController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Equipment> equipmentList = context.Equipments.ToList();
            List<Item> itemList = context.Items.ToList();
            ViewEquipmentViewModel viewEquipmentViewModel = new ViewEquipmentViewModel
            {
                Equipments = equipmentList,
                
                Items = itemList
            };
            
            return View(viewEquipmentViewModel);
        }
        public IActionResult Add()
        {
            AddEquipmentViewModel addEquipmentViewModel = new AddEquipmentViewModel();
            return View(addEquipmentViewModel);
        }
        [HttpPost]
        public IActionResult Add(AddEquipmentViewModel addEquipmentViewModel)
        {
            if (ModelState.IsValid)
            {

                Equipment newEquipment = new Equipment
                {
                    Name = addEquipmentViewModel.Name,
                    Price = addEquipmentViewModel.Price
                  
                };
                //Item newItem = new Item
                //{
                //    Equipment=newEquipment,
                //    EquipmentID=newEquipment.ID
                //};
                //context.Add(newItem);
                context.Add(newEquipment);
                context.SaveChanges();
                return Redirect("/Equipment/ViewEquipment/" + newEquipment.ID);
            }
            return View(addEquipmentViewModel);
        }
        public IActionResult ViewEquipment(int id)
        {
            try
            {
                Equipment newEquipment =
                    context.Equipments.Single(e => e.ID == id);

                List<EventEquipment> events = context
                    .EventEquipments
                    .Include(events => events.Event)
                    .Where(cm => cm.EquipmentID == id)
                    .ToList();

                List<Item> items = context
                    .Items
                    .Include(items => items.Equipment)
                    .Where(ei => ei.EquipmentID == id)
                    .ToList();
                
                ViewEquipmentViewModel viewEquipmentViewModel = new ViewEquipmentViewModel
                {
                    Equipment = newEquipment,
                    Events = events,
                    Items= items
                };
                return View(viewEquipmentViewModel);
            }
            catch (InvalidOperationException)
            {
                return Redirect("/Equipment");
            }

        }
        [HttpPost]
        public IActionResult ViewEquipment(int EquipmentID, int NumItems, int TotalItem)
        {
            
                Equipment newEquipment =
                        context.Equipments.Single(e => e.ID == EquipmentID);
            if (NumItems > 0)
            {
                for (int i = 0; i < NumItems; i++)
                {
                    Item newItem = new Item
                    {
                        Equipment = newEquipment,
                        EquipmentID = newEquipment.ID
                    };
                    context.Add(newItem);
                    context.SaveChanges();
                }
            }else if (NumItems<0)
            {
                NumItems *= -1;
                List<Item> items = context
                    .Items
                    .Include(items => items.Equipment)
                    .Where(ei => ei.EquipmentID == newEquipment.ID)
                    .ToList();
                if (TotalItem <= NumItems)
                {
                    NumItems = TotalItem;
                }
                for (int i=0;i<NumItems;i++)
                {
                    Item theItem = context.Items.Single(e => e.ID == items[i].ID);
                    context.Items.Remove(theItem);
                }
                context.SaveChanges();
            }
            return Redirect("/Equipment/ViewEquipment/"+EquipmentID);
        }
        public IActionResult Remove()
        {
            ViewBag.title = "Remove Equipment:";
            ViewBag.equipments = context.Equipments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] equipmentIds)
        {
            foreach (int equipmentId in equipmentIds)
            {
                Equipment theEquipment = context.Equipments.Single(e => e.ID == equipmentId);
                context.Equipments.Remove(theEquipment);
            }

            context.SaveChanges();

            return Redirect("/Equipment");
        }
    }
}
