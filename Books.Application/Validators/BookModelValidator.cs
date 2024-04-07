using Books.Application.Book.DTOs;
using FluentValidation;

namespace Books.Application.Validators
{
    public class BookModelValidator : AbstractValidator<BookCreateModel>
    {
        public BookModelValidator()
        {
            RuleFor(attribute => attribute.Name)
                .NotNull().WithMessage("Nome precisa ser preenchido")
                .NotEmpty().WithMessage("Nome não pode ser vazio");

            RuleFor(attribute => attribute.Description)
                .Length(5, 800).WithMessage("Descrição precisa estar entre 5 e 800 caracteres")
                .NotNull().WithMessage("Descrição não pode ser null");
        }
    }
}