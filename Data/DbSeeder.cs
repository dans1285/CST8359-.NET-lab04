using Lab4WorkshopRsvp.Models;

namespace Lab4WorkshopRsvp.Data
{
    public static class DbSeeder
    {
        // Seed data
        public static void SeedData(ApplicationDbContext context)
        {
            if (!context.Rsvps.Any())
            {
                context.Rsvps.AddRange(
                    new Rsvp { FullName = "Michael Chen", Email = "michael.c@example.com", WorkshopTitle = "Intro to EF Core", NeedsAccommodation = false, RegistrationDate = DateTime.Now.AddDays(-2) },
                    new Rsvp { FullName = "Sarah Williams", Email = "swilliams88@example.com", WorkshopTitle = "Advanced ASP.NET Core", NeedsAccommodation = true, RegistrationDate = DateTime.Now.AddDays(-1) }
                );
                context.SaveChanges();
            }
        }
    }
}
