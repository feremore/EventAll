using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventAll.Data;
using EventAll.Models;
using EventAll.ViewModels;
using EventAll.ViewModels.Event;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventAll.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext context;

        public EventController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {

            IList<Event> events = context.Events.Include(v => v.Venue)
                .OrderBy(r => r.Date)
                .ToList();
            
            
            return View(events);
        }
        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel(context.Venues.ToList());
            return View(addEventViewModel);
        }
        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                Venue venue = context.Venues.Single(v => v.ID == addEventViewModel.VenueID);
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    Budget = addEventViewModel.Budget,
                    Venue = venue,
                    Date = addEventViewModel.Date
                    
                };
                context.Add(newEvent);
                context.SaveChanges();
                return Redirect("/Event/ViewEvent/" + newEvent.ID);
            }
            return View(addEventViewModel);
        }
        public IActionResult ViewEvent(int id)
        {
            try
            {
                Event newEvent =
                        context.Events.Single(e => e.ID == id);
                Venue newVenue =
                        context.Venues.Single(v => v.ID == newEvent.VenueID);
                List<EventStaff> staffs = context
                .EventStaffs
                .Include(staffs => staffs.Staff)
                .Where(cm => cm.EventID == id)
                .ToList();

                List<EventEquipment> equipments = context
                .EventEquipments
                .Include(equipments => equipments.Equipment)
                .Where(cm => cm.EventID == id)
                .ToList();
                
                List<Item> items = context
                    .Items
                    .Include(items => items.Equipment)
                    .Where(ei => ei.EquipmentID == id)
                    .ToList();


                ViewEventViewModel viewEventViewModel = new ViewEventViewModel(context.Equipments.ToList(), context.Staffs.ToList())
                {
                    Event = newEvent,
                    Staffs=staffs,
                    Equipments=equipments,
                    Venue=newVenue,
                    Items= items


                };
                return View(viewEventViewModel);
            }
            catch (InvalidOperationException)
            {
                return Redirect("/Event");
            }

        }
        [HttpPost]
        public IActionResult AddEquipment(ViewEventViewModel viewEventViewModel, int EventID)
        {
            if (ModelState.IsValid)
            {

                IList<EventEquipment> existingItems = context.EventEquipments
        .Where(ee => ee.EventID == EventID)
        .Where(ee => ee.EquipmentID == viewEventViewModel.EquipmentID).ToList();
                if (!existingItems.Any())
                {

                    EventEquipment eventEquipment = new EventEquipment
                    {
                        EquipmentID = viewEventViewModel.EquipmentID,

                        EventID = EventID

                    };

                    context.EventEquipments.Add(eventEquipment);
                    context.SaveChanges();
                    
                }
                
            }
            return Redirect("/Event/ViewEvent/" + EventID);
        }
        [HttpPost]
        public IActionResult AddEquipmentItems(int EventID, int EquipmentID, int NumItems, int TotalItem)
        {

            Equipment newEquipment =
                    context.Equipments.Single(e => e.ID == EquipmentID);
            Event newEvent =
                    context.Events.Single(e => e.ID == EventID);
            if (NumItems > 0 && NumItems>TotalItem)
            {
                for (int i = 0; i < NumItems-TotalItem; i++)
                {
                    Item newItem = new Item
                    {
                        Equipment = newEquipment,
                        EquipmentID = newEquipment.ID
                    };
                    context.Add(newItem);
                    context.SaveChanges();
                }
                
                newEvent.TotalCost += (NumItems - TotalItem) * newEquipment.Price;
                context.Events.Add(newEvent);
                context.SaveChanges();
            }
            return Redirect("/Event/ViewEvent/" + EventID);
        }

            public IActionResult Remove()
        {
            ViewBag.title = "Remove Events:";
            ViewBag.objs = context.Events.ToList();
            ViewBag.objName = "Event(s)";
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] objIds)
        {
            foreach (int eventId in objIds)
            {
                Event theEvent = context.Events.Single(e => e.ID == eventId);
                context.Events.Remove(theEvent);
            }

            context.SaveChanges();

            return Redirect("/Event");
        }
    }
}
