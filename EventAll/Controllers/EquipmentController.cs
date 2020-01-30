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
        //datebase reference
        private readonly ApplicationDbContext context;

        public EquipmentController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        // Populates Equipment List and Items List and passes view model into view.
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
        // Declares a new ViewModel for adding equipment and passes it into view. 
        public IActionResult Add()
        {
            AddEquipmentViewModel addEquipmentViewModel = new AddEquipmentViewModel();
            return View(addEquipmentViewModel);
        }
        [HttpPost]
        //Build Equipment object and add to database
        public IActionResult Add(AddEquipmentViewModel addEquipmentViewModel)
        {
            if (ModelState.IsValid)
            {

                Equipment newEquipment = new Equipment
                {
                    Name = addEquipmentViewModel.Name,
                    Price = addEquipmentViewModel.Price
                  
                };
                
                context.Add(newEquipment);
                context.SaveChanges();
                return Redirect("/Equipment/ViewEquipment/" + newEquipment.ID);
            }
            return View(addEquipmentViewModel);
        }
        //Builds a view for a Equipment.ID == id.
        public IActionResult ViewEquipment(int id)
        {
            try
            {
                Equipment newEquipment =
                    context.Equipments.Single(e => e.ID == id);
                //Populates a list of EventEquipment relationships that have events related to newEquipment.
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
        //Adds Items of a specific Equipment ID to the database from values from view.
        [HttpPost]
        public IActionResult ViewEquipment(int EquipmentID, int NumItems, int TotalItem)
        {
            
                Equipment newEquipment =
                        context.Equipments.Single(e => e.ID == EquipmentID);
            //If User inputs postive number it makes a new Item NumItems amount of times.
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
            //If User inputs negative number it removes Items from database the amount of NumItems.
            }
            else if (NumItems<0)
            {
                NumItems *= -1;
                //Populates a list of Items with EquipmentID == newEquipment.ID
                List<Item> items = context
                    .Items
                    .Include(items => items.Equipment)
                    .Where(ei => ei.EquipmentID == newEquipment.ID)
                    .ToList();
                //If the total amount of items in database is less than NumItems then change NumItems to TotalItem.
                if (TotalItem <= NumItems)
                {
                    NumItems = TotalItem;
                }
                //Removes items in list from the database.
                for (int i=0;i<NumItems;i++)
                {
                    Item theItem = context.Items.Single(e => e.ID == items[i].ID);
                    context.Items.Remove(theItem);
                }
                context.SaveChanges();
            }
            return Redirect("/Equipment/ViewEquipment/"+EquipmentID);
        }
        //Populates list of all Equipment and pass to view.
        public IActionResult Remove()
        {
            ViewBag.title = "Remove Equipment:";
            ViewBag.objs = context.Equipments.ToList();
            ViewBag.objName = "Equipment";
            return View();
        }

        [HttpPost]
        //Using the list of ids remove equipment for each id in objIds.
        public IActionResult Remove(int[] objIds)
        {
            foreach (int equipmentId in objIds)
            {
                Equipment theEquipment = context.Equipments.Single(e => e.ID == equipmentId);
                context.Equipments.Remove(theEquipment);
            }

            context.SaveChanges();

            return Redirect("/Equipment");
        }
    }
}
