namespace Lab3WorkshopRsvp.Models
{
    public class Rsvp
    {
        public string FullName { get; set; } = string.Empty;
        public bool NeedsAccommodation { get; set; }
        public string WorkshopTitle { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
    }
}
