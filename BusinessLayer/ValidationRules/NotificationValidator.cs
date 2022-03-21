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
            RuleFor(x => x.NotificationDetails).NotEmpty().MinimumLength(2);
            RuleFor(x => x.NotificationType).NotEmpty().MinimumLength(2);
            RuleFor(x => x.NotificationStatus).NotEmpty();
        }
    }
}
