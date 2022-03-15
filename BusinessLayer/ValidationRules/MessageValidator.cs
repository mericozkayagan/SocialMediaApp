using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.Reciever).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Sender).NotEmpty().MinimumLength(3);
            RuleFor(x => x.MessageDetails).NotEmpty().MinimumLength(3);
            RuleFor(x => x.MessageDate).NotEmpty();
        }
    }
}
