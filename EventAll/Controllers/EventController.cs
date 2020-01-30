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

namespace EventAll.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext context;

        public EventController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        //Populates a list of Events and Venue of each event ordered by earliest date and passes it into view.
        public IActionResult Index()
        {

            IList<Event> events = context.Events.Include(v => v.Venue)
                .OrderBy(r => r.Date)
                .ToList();
            
            
            return View(events);
        }
        //Pass AddEventViewModel with list of Venues into View.
        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel(context.Venues.ToList());
            return View(addEventViewModel);
        }
        [HttpPost]
        //Build Event Object from ViewModel and save to database and redirect to ViewEvent view with Event ID.
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                Venue venue = context.Venues.Single(v => v.ID == addEventViewModel.VenueID);
                //Event Constructor
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
        //Builds ViewEvent page of a specific event based on id.
        public IActionResult ViewEvent(int id)
        {
            try
            {
                
                Event newEvent =
                        context.Events.Single(e => e.ID == id);
                Venue newVenue =
                        context.Venues.Single(v => v.ID == newEvent.VenueID);
                //populate list of staff linked to current event.
                List<EventStaff> staffs = context
                .EventStaffs
                .Include(staffs => staffs.Staff)
                .Where(cm => cm.EventID == id)
                .ToList();
                //populate list of equipment linked to current event.
                List<EventEquipment> equipments = context
                .EventEquipments
                .Include(equipments => equipments.Equipment)
                .Where(cm => cm.EventID == id)
                .ToList();
                //populate a list of items
                List<Item> items = context
                    .Items
                    .ToList();

                //viewmodel of event.
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
        //Create a relationship between current Event and an Equipment.
        public IActionResult AddEquipment(ViewEventViewModel viewEventViewModel, int EventID)
        {
            if (ModelState.IsValid)
            {
                //if a relationship already exists between an Event object and Equipment object it adds EventEquipment 
                //object to list.
                IList<EventEquipment> existingItems = context.EventEquipments
        .Where(ee => ee.EventID == EventID)
        .Where(ee => ee.EquipmentID == viewEventViewModel.EquipmentID).ToList();
                if (!existingItems.Any())
                {
                    //EventEquipment Constructor
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
        //Create a relationship between current Event and an Staff.
        public IActionResult AddStaff(ViewEventViewModel viewEventViewModel, int EventID)
        {
            if (ModelState.IsValid)
            {
                //if a relationship already exists between an Event object and Staff object it adds EventStaff 
                //object to list.
                IList<EventStaff> existingItems = context.EventStaffs
        .Where(es => es.EventID == EventID)
        .Where(es => es.StaffID == viewEventViewModel.StaffID).ToList();
                if (!existingItems.Any())
                {
                    //EventStaff Constructor
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
        //Add/Removes Items to Equipment Inventory.
        public IActionResult AddOrRemoveEquipmentItems(int EventID, int EquipmentID, int NumItems, int TotalItem)
        {

            Equipment newEquipment =
                    context.Equipments.Single(e => e.ID == EquipmentID);
            Event newEvent =
                    context.Events.Single(e => e.ID == EventID);

            //Populates a list of Items with CurrentEventId == EventID
            IList<Item> eventItems = context.Items.Where(i => i.CurrentEventId == EventID).ToList();

            //Prevents Adding Items to database if NumItems is less then TotalItems.
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
            //if items with event id are more then 0 
            else if(NumItems<0 && eventItems.Count()>0)
            {
                NumItems *= -1;
                //if NumItems is more then items with event id then numItems = eventItems.Count()
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
        //Populates list of Events passes to view
            public IActionResult Remove()
        {
            ViewBag.title = "Remove Events:";
            ViewBag.objs = context.Events.ToList();
            ViewBag.objName = "Event(s)";
            return View();
        }

        [HttpPost]
        //Using the list of ids remove Event for each id in objIds.
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
        // Add/Remove Staff Hours to EventStaff Table
        public IActionResult AddOrRemoveHours(int Hours,int EventID,int StaffID)
        {
            Event newEvent =
                        context.Events.Single(e => e.ID == EventID);
            Staff newStaff =
                        context.Staffs.Single(s => s.ID == StaffID);
            //Pull specific EventStaff Object to add/remove hours
            EventStaff eventStaff = context.EventStaffs.Single(es => es.EventID == EventID && es.StaffID == StaffID);
            if (Hours > 0)
            {
                newEvent.TotalCost += newStaff.Wage * Hours;
                eventStaff.Hours += Hours;
                
            }else if (Hours<0)
            {
                Hours *= -1;
                //if Hours to remove is more then eventStaff.Hours then set Hours to equal eventStaff.Hours
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
        public IActionResult ChangeBudget(double budget, int EventID)
        {
            Event newEvent =
                        context.Events.Single(e => e.ID == EventID);
            if (budget > 0)
            {
                newEvent.Budget = budget;
            }
            context.SaveChanges();
            return Redirect("/Event/ViewEvent/" + EventID);
        }
        [HttpPost]
        // Add/Subtract from Event.MiscCost
        public IActionResult AddOrRemoveMisc(double MiscCost, int EventID)
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
                //prevents negative MiscCost value
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
        //Populate List of EventEquipment that EventID==id, and then pass into view.
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
        //Using the list of ids remove Equipment from Event for each id in objIds.
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
                    //populate a list of items that have EquipmentID == current equipment id
                    List<Item> items = context
                    .Items
                    .Include(items => items.Equipment)
                    .Where(ei => ei.EquipmentID == equipmentId)
                    .ToList();
                    foreach (var item in items)
                    {
                        //Remove Items with CurrentEventId equal to EventID
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
        //Populate List of EventStaff that EventID==id, and then pass into view.
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
        //Using the list of ids remove Staff from Event for each id in objIds.
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
