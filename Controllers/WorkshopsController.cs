using Microsoft.AspNetCore.Mvc;
using Lab3WorkshopRsvp.Models;

namespace Lab3WorkshopRsvp.Controllers
{
    public class WorkshopsController : Controller
    {
        // Static list to store registrations in memory
        private static List<Rsvp> registrations = new List<Rsvp>();

        // GET: Workshops/Index
        public IActionResult Index()
        {
            return View();
        }

        // GET: Workshops/RsvpForm
        public IActionResult RsvpForm()
        {
            return View();
        }

        // POST: Workshops/Confirm
        [HttpPost]
        public IActionResult Confirm(Rsvp model)
        {
            if (ModelState.IsValid)
            {
                // Add to registrations list
                model.RegistrationDate = DateTime.Now;
                registrations.Add(model);

                // Set confirmation message
                ViewData["Message"] = $"Thanks for registering, {model.FullName}!";
                
                // Return strongly typed view with model
                return View(model);
            }

            // If model is invalid, return to form
            return View("RsvpForm", model);
        }

        // GET: Workshops/Registrations
        public IActionResult Registrations()
        {
            return View(registrations);
        }
    }
}
