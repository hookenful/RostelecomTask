using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using RostelecomTask.Api.Resources;

namespace RostelecomTask.Api.Validators
{
    public class SaveUserResourceValidator: AbstractValidator<SaveUserResource>
    {
        public SaveUserResourceValidator()
        {
            RuleFor(p => p.UserName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(p => p.FullName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(p => p.DepartmentId)
                .NotEmpty()
                .WithMessage("'Department Id' can't be 0.");
        }
    }
}
