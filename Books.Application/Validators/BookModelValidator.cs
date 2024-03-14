using Books.Application.DTOs;
using FluentValidation;

namespace Books.Application.Validators
{
    public class BookModelValidator : AbstractValidator<BookCreateModel>
    {
        public BookModelValidator()
        {
            RuleFor(attribute => attribute.Name).NotNull();
        }
    }
}