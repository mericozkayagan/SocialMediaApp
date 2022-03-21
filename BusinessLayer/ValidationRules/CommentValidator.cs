using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.CommentContent).NotNull().WithMessage("Lütfen yorumunuza içerik giriniz");
            RuleFor(x => x.CommentDate).NotNull();
            RuleFor(x => x.CommentStatus).NotNull();
            RuleFor(x => x.PostId).GreaterThan(0);
            RuleFor(x => x.UserId).GreaterThan(0);
        }
    }
}
