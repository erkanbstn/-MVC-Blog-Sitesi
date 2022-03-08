using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class HeadingValidation : AbstractValidator<Heading>
    {
        public HeadingValidation()
        {
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Başlık Adını Boş Geçemezsiniz.");
            RuleFor(x => x.HeadingName).MinimumLength(3).WithMessage("Başlık 3 Karakterden Uzun Olmalıdır.");
            RuleFor(x => x.HeadingName).MaximumLength(30).WithMessage("Lütfen 30 Karakterden Fazla Değer Girişi Yapmayın.");
        }
    }
}
