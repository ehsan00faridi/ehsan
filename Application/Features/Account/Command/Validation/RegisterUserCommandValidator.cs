using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Account.Command.Validation
{
    

    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress().WithMessage("ایمیل درست نیست!");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8);

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password)
                .WithMessage("تکرار پسورد اشتباه هست!");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .Matches(@"^\+?\d{10,15}$")
                .WithMessage("Invalid phone number format");
        }
    }

}
