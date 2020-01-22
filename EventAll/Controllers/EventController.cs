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
            List<Event> events = context.Events.ToList();
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



                ViewEventViewModel viewEventViewModel = new ViewEventViewModel
                {
                    Event = newEvent,
                    Staffs=staffs,
                    Equipments=equipments


                };
                return View(viewEventViewModel);
            }
            catch (InvalidOperationException)
            {
                return Redirect("/Venue");
            }

        }
    }
}
