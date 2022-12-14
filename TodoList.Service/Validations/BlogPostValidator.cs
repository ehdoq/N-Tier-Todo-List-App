using FluentValidation;
using TodoList.Core.DTOs.Concrete;

namespace TodoList.Service.Validations
{
    public class BlogPostValidator : AbstractValidator<BlogPostDto>
    {
        public BlogPostValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("{PropertyName} Boş olamaz!")
                                 .NotNull().WithMessage("{PropertyName} Boş olamaz!")
                                 .MaximumLength(150).WithMessage("{PropertyName} 150 karakterden fazla olamaz!");

            RuleFor(x => x.Title).NotEmpty().WithMessage("{PropertyName} Boş olamaz!")
                                 .NotNull().WithMessage("{PropertyName} Boş olamaz!");
        }
    }
}