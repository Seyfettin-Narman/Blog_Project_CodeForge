using FluentValidation;
using SeyfBlog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeyfBlog.Service.FluentValidations
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(x => x.Title).NotEmpty().NotNull().MaximumLength(150).WithName("Başlık");
            RuleFor(x => x.Content).NotNull().NotEmpty().WithName("İçerik");
        }

    }
}
