using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingEventsDemo.Controllers
{
    public class EventCategoryController : Controller
    {
        private EventDbContext context;

        public EventCategoryController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        /*[HttpGet]*/
        public IActionResult Index()
        {
            ViewBag.title = "All Categories";
            List<EventCategory> categories = context.Categories.ToList();
            return View(categories);
        }


        public IActionResult Create()
        {
            AddEventCategoryViewModel viewModel = new AddEventCategoryViewModel();
            return View(viewModel);
        }
        [HttpPost]
        /*[Route("")]*/
        public IActionResult ProcessCreateEventCategoryForm(AddEventCategoryViewModel addEventCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                EventCategory eventCategory = new EventCategory
                {
                    Name = addEventCategoryViewModel.Name,
                  
                };

                context.Categories.Add(eventCategory);
                context.SaveChanges();
                ViewBag.title = "All Categories";
                List<EventCategory> categories = context.Categories.ToList();

                return View("Index", categories);
            }

            return View("Create", addEventCategoryViewModel);
            
        }
    }
}
