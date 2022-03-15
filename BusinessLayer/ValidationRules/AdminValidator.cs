using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Adınız boş olamaz")
                .MinimumLength(2).WithMessage("En az iki harf giriniz")
                .MaximumLength(50).WithMessage("En fazla 50 karakter giriniz");

            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyadınız boş olamaz")
                .MinimumLength(2).WithMessage("En az iki harf giriniz")
                .MaximumLength(50).WithMessage("En fazla 50 karakter giriniz");

            RuleFor(x => x.Email).NotEmpty().MinimumLength(2).WithMessage("Adınız boş olamaz");

            RuleFor(x => x.Password).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapın")
                    .Matches(@"[A-Z]+").WithMessage("Şifreniz en az bir büyük harf içermeli.")
                    .Matches(@"[a-z]+").WithMessage("Şifreniz en az bir küçük harf içermeli.");
        }
    }
}
