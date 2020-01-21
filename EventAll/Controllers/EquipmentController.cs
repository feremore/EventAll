﻿using System;
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
            return View(equipmentList);
        }
        public IActionResult Add()
        {
            AddStaffViewModel addStaffViewModel = new AddStaffViewModel();
            return View(addStaffViewModel);
        }
        [HttpPost]
        public IActionResult Add(AddStaffViewModel addStaffViewModel)
        {
            if (ModelState.IsValid)
            {

                Staff newStaff = new Staff
                {
                    Name = addStaffViewModel.Name,
                    Skill = addStaffViewModel.Job,
                    Wage = addStaffViewModel.Wage
                };
                context.Add(newStaff);
                context.SaveChanges();
                return Redirect("/Staff/ViewStaff/" + newStaff.ID);
            }
            return View(addStaffViewModel);
        }
        public IActionResult ViewStaff(int id)
        {
            try
            {
                Staff newStaff =
                        context.Staffs.Single(s => s.ID == id);
                List<EventStaff> events = context
                .EventStaffs
                .Include(events => events.Event)
                .Where(cm => cm.StaffID == id)
                .ToList();

                ViewStaffViewModel viewStaffViewModel = new ViewStaffViewModel
                {
                    Staff = newStaff,
                    Events = events
                };
                return View(viewStaffViewModel);
            }
            catch (InvalidOperationException)
            {
                return Redirect("/Staff");
            }

        }
        [HttpPost]
        public IActionResult ViewStaff(ViewStaffViewModel viewStaffView)
        {

            return View(viewStaffView);
        }
        public IActionResult Remove()
        {
            ViewBag.title = "Remove Staff:";
            ViewBag.staffs = context.Staffs.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] staffIds)
        {
            foreach (int staffId in staffIds)
            {
                Staff theStaff = context.Staffs.Single(v => v.ID == staffId);
                context.Staffs.Remove(theStaff);
            }

            context.SaveChanges();

            return Redirect("/Staff");
        }
    }
}
