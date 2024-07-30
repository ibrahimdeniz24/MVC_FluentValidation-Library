using MVC_FluentValidation.Entites;

namespace MVC_FluentValidation.Models
{
    public class PassengerUpdateVM
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? TicketNumber { get; set; }

        public Gender? Gender { get; set; }
    }
}
