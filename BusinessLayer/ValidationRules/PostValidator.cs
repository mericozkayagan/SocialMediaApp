using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("Bir kategori giriniz");

            RuleFor(x => x.Content).NotEmpty().WithMessage("Bir içerik giriniz.")
                .MinimumLength(2).WithMessage("En az iki karakter giriniz.")
                .MaximumLength(500).WithMessage("En fazla 500 karakter giriniz");

            RuleFor(x => x.Title).NotEmpty().WithMessage("Bir içerik giriniz.")
                .MinimumLength(2).WithMessage("En az iki karakter giriniz.")
                .MaximumLength(500).WithMessage("En fazla 500 karakter giriniz");

            RuleFor(x => x.PostStatus).NotEmpty();
            RuleFor(x => x.CreateDate).NotEmpty();
            RuleFor(x => x.LastUpdatedDate).NotEmpty();
            
        }
    }
}
