using FluentValidation;
using TodoList.Core.DTOs.Concrete;

namespace TodoList.Service.Validations
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("{PropertyName} Boş olamaz!")
                                     .NotNull().WithMessage("{PropertyName} Boş olamaz!")
                                     .MaximumLength(50).WithMessage("{PropertyName} 50 karakterden fazla olamaz!");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("{PropertyName} Boş olamaz!")
                                    .NotNull().WithMessage("{PropertyName} Boş olamaz!")
                                    .MaximumLength(50).WithMessage("{PropertyName} 50 karakterden fazla olamaz!");
        }
    }
}