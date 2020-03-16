using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoRental.Dtos;

namespace VideoRental.Controllers.Validators
{
    public class MoviesValidator : AbstractValidator<MovieDto>
    {
        public MoviesValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.ReleaseDate)
                .NotEmpty()
                .NotNull();
            
        }
    }
}