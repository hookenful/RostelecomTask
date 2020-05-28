using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using RostelecomTask.Api.Resources;

namespace RostelecomTask.Api.Validators
{
    public class SaveDepartmentResourceValidator: AbstractValidator<SaveDepartmentResource>
    {
        public SaveDepartmentResourceValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
