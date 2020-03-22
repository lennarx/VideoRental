using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoRental.ViewModels;

namespace VideoRental.Controllers.Validators
{
    public class RentalValidator : AbstractValidator<NewRentViewModel>
    {
        public RentalValidator()
        {
            RuleFor(x => x.CustomerId)
                .GreaterThan(0)
                .WithMessage("A Customer must be selected");

            RuleFor(x => x.MoviesId)
                .NotEmpty()
                .WithMessage("A Movie must be selected");
        }
    }
}