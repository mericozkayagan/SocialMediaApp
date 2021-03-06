using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
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

            RuleFor(x => x.UserStatus).NotNull();

            RuleFor(x => x.CreatedDate).NotNull();

            RuleFor(x => x.Description).NotNull().WithMessage("Lütfen açıklamanızı giriniz")
                   .MinimumLength(3).WithMessage("Lütfen en az 3 harf giriniz")
                   .MaximumLength(500).WithMessage("Lütfen en fazla 500 karakter giriniz");
                    
        }
    }
}
