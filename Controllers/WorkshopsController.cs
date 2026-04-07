using Microsoft.AspNetCore.Mvc;
using Lab4WorkshopRsvp.Models;
using Lab4WorkshopRsvp.Data;

namespace Lab4WorkshopRsvp.Controllers
{
    public class WorkshopsController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor
        public WorkshopsController(ApplicationDbContext context)
        {
            _context = context;
        }

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
            // Validation
            if (ModelState.IsValid)
            {
                model.RegistrationDate = DateTime.Now;

                _context.Rsvps.Add(model);
                _context.SaveChanges();

                ViewData["Message"] = $"Thanks for registering, {model.FullName}!";
                
                // Return strongly-typed View with the model so we can display details back to the user.
                return View(model);
            }

            return View("RsvpForm", model);
        }

        // GET: Workshops/Registrations
        public IActionResult Registrations()
        {
            return View(_context.Rsvps.ToList());
        }
    }
}
