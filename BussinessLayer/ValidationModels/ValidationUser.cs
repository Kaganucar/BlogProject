using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationModels
{
    public class ValidationUser:AbstractValidator<TBLUser>
    {
        public ValidationUser() 
        {
            RuleFor(x=>x.Password).MaximumLength(50).MinimumLength(5).WithMessage("Minimum 5 , Maximum 50 Karakter Girilebilir. ");
            RuleFor(x=>x.Email).MaximumLength(50).MinimumLength(5).WithMessage("Minimum 5 , Maximum 50 Karakter Girilebilir. ");
        }
    }
}
