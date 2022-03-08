using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidation : AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz.");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklamayı Boş Geçemezsiniz.");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori Adı 3 Karakterden Uzun Olmalıdır.");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Lütfen 20 Karakterden Fazla Değer Girişi Yapmayın.");
            RuleFor(v => v.CategoryDescription).MaximumLength(500).WithMessage("Açıklama Alanını En Fazla 500 Karakter Girebilirsiniz.");
            RuleFor(v => v.CategoryDescription).MinimumLength(5).WithMessage("Açıklama Alanını En Az 5 Karakter Girebilirsiniz.");
        }
    }
}
