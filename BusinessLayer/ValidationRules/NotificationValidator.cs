using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class NotificationValidator : AbstractValidator<Notification>
    {
        public NotificationValidator()
        {
            RuleFor(x => x.NotificationColor).NotEmpty();
            RuleFor(x => x.NotificationDate).NotEmpty();

            RuleFor(x => x.NotificationDetails)
                .NotEmpty().WithMessage("Açıklama kısmı boş olamaz")
                .MinimumLength(2).WithMessage("Lütfen daha uzun bir açıklama giriniz");
            RuleFor(x => x.NotificationType)
                .NotEmpty().WithMessage("Başlık kısmı boş olamaz")
                .MinimumLength(2).WithMessage("Lütfen daha uzun bir başlık giriniz");
            RuleFor(x => x.NotificationStatus).NotEmpty();
        }
    }
}
