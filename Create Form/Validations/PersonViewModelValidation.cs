using FluentValidation;
using Models;

namespace Validations
{
    public class PersonViewModelValidation : AbstractValidator<PersonViewModel>
    {
        public PersonViewModelValidation()
        {
            RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage("Name is Required").MaximumLength(50);
            RuleFor(p => p.Email).NotNull().NotEmpty().WithMessage("Email is Required").EmailAddress();
            RuleFor(p => p.Age).NotNull().NotEmpty().WithMessage("Age is Required");
            RuleFor(p => p.Phone).NotNull().NotEmpty().WithMessage("Phone is Required").Length(11)
            .WithMessage("Phone number must be exactly 11 numbers.").Must(BeValidPhoneNumber).WithMessage("Phone number must be a valid number without +.");
            RuleFor(p => p.Country).NotNull().NotEmpty().WithMessage("Country is Required").MaximumLength(20);
            RuleFor(p => p.City).NotNull().NotEmpty().WithMessage("City is Required").MaximumLength(20);
            RuleFor(p => p.Street).NotNull().NotEmpty().WithMessage("Street is Required").MaximumLength(20);
        }
        private bool BeValidPhoneNumber(string phoneNumber)
        {
            return long.TryParse(phoneNumber, out _);
        }
    }
}
