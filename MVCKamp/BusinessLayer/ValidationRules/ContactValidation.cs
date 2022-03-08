using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidation : AbstractValidator<Contact>
    {
        public ContactValidation()
        {
            RuleFor(b => b.Message).NotEmpty().WithMessage("Boş Mesaj Gönderemezsiniz.");
            RuleFor(b => b.UserMail).NotEmpty().WithMessage("Boş Mail Gönderemezsiniz.");
            RuleFor(b => b.Subject).NotEmpty().WithMessage("Boş Konu Gönderemezsiniz.");
            RuleFor(b => b.UserName).NotEmpty().WithMessage("Boş İsim Gönderemezsiniz.");
            RuleFor(b => b.Subject).MaximumLength(150).WithMessage("Konu En Fazla 150 Karakter Olmalıdır.");
            RuleFor(b => b.Subject).MinimumLength(5).WithMessage("Konu En Az 5 Karakter Olmalıdır.");
            RuleFor(b => b.Message).MinimumLength(5).WithMessage("Mesaj En Az 5 Karakter Olmalıdır.");
            RuleFor(b => b.Message).MaximumLength(1000).WithMessage("Mesaj En Fazla 1000 Karakter Olmalıdır.");
        }
    }
}
