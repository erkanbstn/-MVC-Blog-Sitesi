using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidation : AbstractValidator<Writer>
    {
        public WriterValidation()
        {
            RuleFor(n => n.WriterName).NotEmpty().WithMessage("Yazar Adı Girilmek Zorundadır.");
            RuleFor(n => n.WriterName).MaximumLength(50).WithMessage("Yazar Adı En Fazla 50 Karakter Olabilir.");
            RuleFor(n => n.WriterName).MinimumLength(3).WithMessage("Yazar Adı En Az 3 Karakter Olmak Zorundadır.");


            RuleFor(n => n.WriterSurname).NotEmpty().WithMessage("Yazar Soyadı Girilmek Zorundadır.");
            RuleFor(n => n.WriterSurname).MaximumLength(50).WithMessage("Yazar Soyadı En Fazla 50 Karakter Olabilir.");
            RuleFor(n => n.WriterSurname).MinimumLength(3).WithMessage("Yazar Soyadı En Az 3 Karakter Olmak Zorundadır.");

            RuleFor(n => n.WriterMail).NotEmpty().WithMessage("Yazar Emaili Girilmek Zorundadır.");
            RuleFor(n => n.WriterMail).MaximumLength(50).WithMessage("Yazar Emaili En Fazla 50 Karakter Olabilir.");
            RuleFor(n => n.WriterMail).MinimumLength(3).WithMessage("Yazar Emaili En Az 3 Karakter Olmak Zorundadır.");

            RuleFor(n => n.WriterPassword).NotEmpty().WithMessage("Yazar Parolası Girilmek Zorundadır.");
            RuleFor(n => n.WriterPassword).MaximumLength(50).WithMessage("Yazar Parolası En Fazla 50 Karakter Olabilir.");
            RuleFor(n => n.WriterPassword).MinimumLength(3).WithMessage("Yazar Parolası En Az 3 Karakter Olmak Zorundadır.");

            RuleFor(n => n.WriterAbout).NotEmpty().WithMessage("Yazar Hakkına Kısmı Girilmek Zorundadır.");
            RuleFor(n => n.WriterAbout).MaximumLength(50).WithMessage("Yazar Hakkına Kısmı En Fazla 50 Karakter Olabilir.");
            RuleFor(n => n.WriterAbout).MinimumLength(3).WithMessage("Yazar Hakkına Kısmı En Az 3 Karakter Olmak Zorundadır.");

            RuleFor(n => n.WriterTitle).NotEmpty().WithMessage("Yazar Başlığı Kısmı Girilmek Zorundadır.");
            RuleFor(n => n.WriterTitle).MaximumLength(50).WithMessage("Yazar Başlık Kısmı En Fazla 50 Karakter Olabilir.");
            RuleFor(n => n.WriterTitle).MinimumLength(3).WithMessage("Yazar Başlık Kısmı En Az 3 Karakter Olmak Zorundadır.");


            RuleFor(n => n.WriterImage).NotEmpty().WithMessage("Fotoğraf İsmi Girilmek Zorundadır.");
            RuleFor(n => n.WriterImage).MaximumLength(50).WithMessage("Fotoğraf İsim Uzunluğu En Fazla 500 Karakter Olabilir.");
            RuleFor(n => n.WriterImage).MinimumLength(3).WithMessage("Fotoğraf İsim Uzunluğu En Az 4 Karakter Olmak Zorundadır.");
        }

    }
}
