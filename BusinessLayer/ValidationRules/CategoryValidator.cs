using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotNull().MinimumLength(2).WithMessage("Lütfen daha uzun bir kategori adı giriniz")
                .MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapın");
        }
    }
}
