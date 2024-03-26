using FluentValidation;
using SeyfBlog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeyfBlog.Service.FluentValidations
{
    public class UserValidator : AbstractValidator<IdUser>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).NotNull().WithName("Ad");
            RuleFor(x => x.lastName).NotNull().WithName("Soyad");
            RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Telefon numarası boş olamaz.")
            .Length(10).WithMessage("Telefon numarası 10 karakter olmalıdır.");
  
        }
    }
}
