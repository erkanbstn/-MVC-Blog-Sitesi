using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidation : AbstractValidator<About>
    {
        public AboutValidation()
        {
            RuleFor(b => b.AboutDetails1).NotEmpty().WithMessage("Detay1 Alanı Boş Geçilemez");
            RuleFor(b => b.AboutDetails2).NotEmpty().WithMessage("Detay2 Alanı Boş Geçilemez");
            RuleFor(b => b.AboutDetails1).MaximumLength(200).WithMessage("Detay1 Alanı En Fazla 200 Karakter Olabilir");
            RuleFor(b => b.AboutDetails2).MaximumLength(200).WithMessage("Detay2 Alanı En Fazla 200 Karakter Olabilir");
            RuleFor(b => b.AboutDetails1).MinimumLength(3).WithMessage("Detay1 Alanı En Az 3 Karakter Olabilir");
            RuleFor(b => b.AboutDetails2).MinimumLength(3).WithMessage("Detay2 Alanı En Az 3 Karakter Olabilir");
        }
    }
}
