using APIAbooking.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAbooking.Validator.ClientForValidator
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(x => x.ClientId)
               .NotEqual("0")
               .WithMessage("This field cannot be empty");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("This field cannot be empty");

            RuleFor(x => x.Lastname)
                .NotEmpty()
                .WithMessage("This field cannot be empty");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("This field cannot be empty");

            //RuleFor(x => x.IsExist)
            //    .Equal(true)
            //    .WithMessage("This email now is used, pleas enter a new!");

            
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("This field cannot be empty");
        }
    }
}
