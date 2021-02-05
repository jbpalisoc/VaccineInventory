using CovidVaccine.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccine.Validators
{
    public class PostPatientCommandValidator : AbstractValidator<PostPatientCommand>
    {
        public PostPatientCommandValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.ContactNo).NotEmpty();
            RuleFor(c => c.Birthday).NotEmpty();
        }
    }
}
