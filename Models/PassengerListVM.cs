using MVC_FluentValidation.Entites;

namespace MVC_FluentValidation.Models
{
    public class PassengerListVM
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int TicketNumber { get; set; }

        public Gender Gender { get; set; }
    }
}
