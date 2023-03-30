using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Lütfen kendiniz hakkında birşeyler yazınız.");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail Adresinizi giriniz.");
            RuleFor(x => x.WriterName).NotEmpty().MinimumLength(2).WithMessage("İsiminiz en az 3 harften oluşmalı.");
        }
    }
}
