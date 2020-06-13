using APIAbooking.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAbooking.Validator.Owner
{
    public class OwnerValidator : AbstractValidator<RoomOwner>
    {
        public OwnerValidator()
        {
            //RuleFor(x => x.OwnerId)
            //   .NotEqual(0)
            //   .WithMessage("This field cannot be empty");

            //RuleFor(x => x.Name)
            //    .NotEmpty()
            //    .WithMessage("This field cannot be empty");

            //RuleFor(x => x.Lastname)
            //    .NotEmpty()
            //    .WithMessage("This field cannot be empty");

            //RuleFor(x => x.Email)
            //    .NotEmpty()
            //    .WithMessage("This field cannot be empty");

            //RuleFor(x => x.Email)
            //    .EmailAddress()
            //    .WithMessage("Enter an email addres");

            //RuleFor(x => x.Email)
            //    .NotEqual(x => x.Email)
            //    .WithMessage("This email now is use, please enter a new");

            //RuleFor(x => x.Password)
            //    .NotEmpty()
            //    .WithMessage("This field cannot be empty");
        }
    }
}
