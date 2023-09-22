using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationModels
{
    public class ValidationCategories: AbstractValidator<TBLCategories>
    {
        public ValidationCategories() 
        {
            RuleFor(x => x.CategoryName).MaximumLength(50).MinimumLength(5).WithMessage("Minimum 5 , Maximum 50 Karakter Girilebilir.");
        }
    }
}
