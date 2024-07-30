using FluentValidation;
using MVC_FluentValidation.Models;

namespace MVC_FluentValidation.Validators.PassengersValidators
{
    public class PassengerCreateValidation : AbstractValidator<PassengerCreateVM>
    {

        public PassengerCreateValidation()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("Lütfen Boş Bırakmayın")
                .MaximumLength(15).WithMessage("En Fazla 15 Karakter Girebilirsin")
                .MinimumLength(3).WithMessage("Minimum 3 karakter girmesiniz");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("Lütfen Boş Bırakmayın")
                .MaximumLength(15).WithMessage("En Fazla 15 Karakter Girebilirsin")
                .MinimumLength(3).WithMessage("Minimum 3 karakter girmesiniz");
            RuleFor(p => p.TicketNumber).NotEmpty().WithMessage("Lütfen Boş Bırakmayın")
                .Must(BeAnInt).WithMessage("Sadece Tam Sayi Girebilirsiniz")
                .Matches(@"^\d+$");
            RuleFor(p => p.Gender).NotEmpty().WithMessage("Lütfen Boş Bırakmayın");

        }

        private bool BeAnInt(string ticket)
        {
            return int.TryParse(ticket, out _);

        }
    }
}
