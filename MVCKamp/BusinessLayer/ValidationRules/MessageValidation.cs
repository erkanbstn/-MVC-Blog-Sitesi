using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidation : AbstractValidator<Message>
    {
        public MessageValidation()
        {
            RuleFor(b => b.MessageContent).NotEmpty().WithMessage("Mesaj Alanı Boş Geçilemez.");
            RuleFor(b => b.MessageSubject).NotEmpty().WithMessage("Mesaj Konu Alanı Boş Geçilemez.");
            RuleFor(b => b.ReceiverMail).NotEmpty().WithMessage("Alıcı Alanı Boş Geçilemez.");
            RuleFor(b => b.MessageContent).MinimumLength(5).WithMessage("Mesajınız En Az 5 Karakter Olabilir");
            RuleFor(b => b.MessageSubject).MinimumLength(5).WithMessage("Mesaj Konunuz En Az 5 Karakter Olabilir");
            RuleFor(b => b.MessageSubject).MaximumLength(150).WithMessage("Mesaj Konunuz En Fazla 150 Karakter Olabilir");
            RuleFor(b => b.MessageContent).MaximumLength(1500).WithMessage("Mesajınız En Fazla 1500 Karakter Olabilir");
        }
    }
}
