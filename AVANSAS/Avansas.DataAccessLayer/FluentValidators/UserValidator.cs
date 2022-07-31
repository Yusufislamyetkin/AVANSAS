using Avansas.EntityLayer.Models;
using FluentValidation;
using System;

namespace Avansas.UI.FluentValidators
{
    public class UserValidator : AbstractValidator<User>
    {

        public UserValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().NotNull().WithMessage("* Mail alanı boş bırakılamaz").EmailAddress().WithMessage("* Email alanı doğru formatta olmalıdır.").MaximumLength(30).WithMessage("* Maksimum 30 karakter girişi yapılabilir. "); ;
            RuleFor(x => x.Password).NotEmpty().WithMessage("* Şifre boş olmamalı.").MaximumLength(10).WithMessage("* Maksimum 10 karakter girişi yapılabilir. ");

            RuleFor(x => x.SurName).NotEmpty().WithMessage("* Soyad boş olmamalı.").MaximumLength(30).WithMessage("* Maksimum 30 karakter girişi yapılabilir. "); ;
            RuleFor(x => x.Name).NotEmpty().WithMessage("* İsim boş olmamalı.").MaximumLength(30).WithMessage("* Maksimum 30 karakter girişi yapılabilir. "); ;
            RuleFor(x => x.GsmNumber).NotEmpty().WithMessage("* Telefon Numarası boş olmamalı.").Length(10).WithMessage("* 10 hane olmalı");

            RuleFor(x => x.BirthDate).NotEmpty().NotNull().WithMessage("* Tarih alanı boş olmamalı.");
           

        }
    }
}
