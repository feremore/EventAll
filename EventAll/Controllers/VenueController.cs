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
    public class VenueController : Controller
    {
        private readonly ApplicationDbContext context;

        public VenueController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        // GET: /<controller>/
        
        public IActionResult Index()
        {
            List<Venue> venues = context.Venues.ToList();
            return View(venues);
        }
        public IActionResult Add()
        {
            AddVenueViewModel addVenueViewModel = new AddVenueViewModel();
            return View(addVenueViewModel);
        }
        [HttpPost]
        public IActionResult Add(AddVenueViewModel addVenueViewModel)
        {
            if (ModelState.IsValid)
            {
                Venue newVenue = new Venue
                {
                    Name = addVenueViewModel.Name,
                    Capacity = addVenueViewModel.Capacity,
                    Price = addVenueViewModel.Price
                };
                context.Add(newVenue);
                context.SaveChanges();
                return Redirect("/Venue/ViewVenue/" + newVenue.ID);
            }
            return View(addVenueViewModel);
        }
        public IActionResult ViewVenue(int id)
        {
            try
            {
                Venue newVenue =
                        context.Venues.Single(v => v.ID == id);
                List<EventVenue> events = context
                .EventVenues
                .Include(events => events.Event)
                .Where(cm => cm.VenueID == id)
                .ToList();

                ViewVenueViewModel viewVenueViewModel = new ViewVenueViewModel
                {
                    Venue = newVenue,
                    Events = events
                };
                return View(viewVenueViewModel);
            }
            catch (InvalidOperationException)
            {
                return Redirect("/Venue");
            }
            
        }
        public IActionResult Remove()
        {
            ViewBag.title = "Remove Venue:";
            ViewBag.venues = context.Venues.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] venueIds)
        {
            foreach (int venueId in venueIds)
            {
                Venue theVenue = context.Venues.Single(v => v.ID == venueId);
                context.Venues.Remove(theVenue);
            }

            context.SaveChanges();

            return Redirect("/Venue");
        }
    }
}
