using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datarynx.Models
{
  
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).NotNull().Length(10, 20).WithMessage("First Name Must be between 10,20");
            RuleFor(x => x.LastName).NotNull().Length(10, 20).WithMessage("Last Name Must be between 10,20");

        }
    }
}
