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
                    Date = addEventViewModel.Date,
                    TotalCost= venue.Price
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
        public IActionResult AddStaff(ViewEventViewModel viewEventViewModel, int EventID)
        {
            if (ModelState.IsValid)
            {
                
                IList<EventStaff> existingItems = context.EventStaffs
        .Where(es => es.EventID == EventID)
        .Where(es => es.StaffID == viewEventViewModel.StaffID).ToList();
                if (!existingItems.Any())
                {

                    EventStaff eventStaff = new EventStaff
                    {
                        StaffID = viewEventViewModel.StaffID,

                        EventID = EventID

                    };
                    
                    context.EventStaffs.Add(eventStaff);
                    context.SaveChanges();

                }

            }
            return Redirect("/Event/ViewEvent/" + EventID);
        }
        [HttpPost]
        public IActionResult AddOrRemoveEquipmentItems(int EventID, int EquipmentID, int NumItems, int TotalItem)
        {

            Equipment newEquipment =
                    context.Equipments.Single(e => e.ID == EquipmentID);
            Event newEvent =
                    context.Events.Single(e => e.ID == EventID);
            IList<Item> eventItems = context.Items.Where(i => i.CurrentEventId == EventID).ToList();
            if (NumItems > 0 && NumItems>TotalItem)
            {
                for (int i = 0; i < NumItems-TotalItem; i++)
                {
                    Item newItem = new Item
                    {
                        Equipment = newEquipment,
                        EquipmentID = newEquipment.ID,
                        CurrentEventId = EventID
                    };
                    context.Add(newItem);
                    context.SaveChanges();
                }
                
                newEvent.TotalCost += (NumItems - TotalItem) * newEquipment.Price;


            }
            else if(NumItems<0 && eventItems.Count()>0)
            {
                NumItems *= -1;
                if (NumItems> eventItems.Count())
                {
                    NumItems = eventItems.Count();
                }
                for (int i = 0; i < NumItems; i++)
                {
                    newEvent.TotalCost -= eventItems[i].Equipment.Price;
                    context.Items.Remove(eventItems[i]);
                }

            }
            context.SaveChanges();
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
        [HttpPost]
        public IActionResult AddOrRemoveHours(int Hours,int EventID,int StaffID)
        {
            Event newEvent =
                        context.Events.Single(e => e.ID == EventID);
            Staff newStaff =
                        context.Staffs.Single(s => s.ID == StaffID);
            EventStaff eventStaff = context.EventStaffs.Single(es => es.EventID == EventID && es.StaffID == StaffID);
            if (Hours > 0)
            {
                newEvent.TotalCost += newStaff.Wage * Hours;
                eventStaff.Hours += Hours;
                
            }else if (Hours<0)
            {
                Hours *= -1;
                if (Hours > eventStaff.Hours)
                {
                    Hours = eventStaff.Hours;
                }
                newEvent.TotalCost -= newStaff.Wage * Hours;
                eventStaff.Hours -= Hours;
            }
            context.SaveChanges();
            return Redirect("/Event/ViewEvent/" + EventID);
        }
        [HttpPost]
        public IActionResult AddMisc(double MiscCost, int EventID)
        {
            Event newEvent =
                        context.Events.Single(e => e.ID == EventID);
            if (MiscCost > 0)
            {                
                newEvent.MiscCost += MiscCost;
                newEvent.TotalCost += MiscCost;
                
            }
            else if(MiscCost<0)
            {
                if (MiscCost * -1 > newEvent.MiscCost)
                {
                    newEvent.TotalCost -=newEvent.MiscCost;
                    newEvent.MiscCost = 0;                    
                }
                else
                {
                    newEvent.MiscCost += MiscCost;
                    newEvent.TotalCost += MiscCost;
                }

            }
            context.SaveChanges();
            return Redirect("/Event/ViewEvent/" + EventID);
        }
        public IActionResult RemoveEquipment(int id)
        {
           List<EventEquipment> equipments = context
                .EventEquipments
                .Include(equipments => equipments.Equipment)
                .Where(cm => cm.EventID == id)
                .ToList();

            ViewBag.title = "Remove Equipment From Event:";
            ViewBag.objs = equipments;
            ViewBag.objName = "Equipment";
            return View();
        }
        [HttpPost]
        public IActionResult RemoveEquipment(int[] objIds, int id)
        {
            if (ModelState.IsValid)
            {
                Event newEvent =
                            context.Events.Single(e => e.ID == id);
                foreach (int equipmentId in objIds)
                {
                    EventEquipment theEventEquipment = context.EventEquipments
                        .Single(ee => ee.EventID == id && ee.EquipmentID == equipmentId);
                    List<Item> items = context
                    .Items
                    .Include(items => items.Equipment)
                    .Where(ei => ei.EquipmentID == equipmentId)
                    .ToList();
                    foreach (var item in items)
                    {
                        if (item.CurrentEventId == id)
                        {
                            context.Items.Remove(item);
                            newEvent.TotalCost -= theEventEquipment.Equipment.Price;
                        }
                    }
                    context.EventEquipments.Remove(theEventEquipment);
                }

                context.SaveChanges();
            }
            return Redirect("/Event/ViewEvent/"+id);
        }
        public IActionResult RemoveStaff(int id)
        {
            ViewBag.title = "Remove Staff From Event:";
            ViewBag.objs = context
                .EventStaffs
                .Include(staffs => staffs.Staff)
                .Where(cm => cm.EventID == id)
                .ToList();
            ViewBag.objName = "Staff";
            return View();
        }
        [HttpPost]
        public IActionResult RemoveStaff(int[] objIds, int id)
        {
            Event newEvent =
                        context.Events.Single(e => e.ID == id);
            
            foreach (int staffId in objIds)
            {
                EventStaff theEventStaff = context.EventStaffs
                    .Single(es => es.EventID == id && es.StaffID == staffId);
                Staff newStaff =
                        context.Staffs.Single(s => s.ID == staffId);
                newEvent.TotalCost -= theEventStaff.Hours * newStaff.Wage;
                
                context.EventStaffs.Remove(theEventStaff);
            }

            context.SaveChanges();

            return Redirect("/Event/ViewEvent/" + id);
        }
    }
}
