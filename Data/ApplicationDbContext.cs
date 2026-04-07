using Lab4WorkshopRsvp.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4WorkshopRsvp.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSets
        public DbSet<Rsvp> Rsvps { get; set; }
    }
}
