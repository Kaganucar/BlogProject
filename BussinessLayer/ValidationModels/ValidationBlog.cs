using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationModels
{
    public class ValidationBlog:AbstractValidator<TBLBlog>
    {
        public ValidationBlog() 
        { 
            RuleFor(x=> x.BlogName).MaximumLength(50).MinimumLength(5).WithMessage("Minimum 5 , Maximum 50 Karakter Girilebilir. ");
            RuleFor(x=> x.Title).MaximumLength(50).MinimumLength(5).WithMessage("Minimum 5 , Maximum 50 Karakter Girilebilir. ");
        }
    }
}
