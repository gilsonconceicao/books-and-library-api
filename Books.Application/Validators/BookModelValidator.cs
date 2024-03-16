using Books.Application.DTOs.Book;
using FluentValidation;

namespace Books.Application.Validators
{
    public class BookModelValidator : AbstractValidator<BookCreateModel>
    {
        public BookModelValidator()
        {
            RuleFor(attribute => attribute.Name)
                .NotNull().WithMessage("Nome precisa ser preenchido")
                .NotEmpty().WithMessage("Nome não pode ser vazio")
                .WithMessage("Por favor, forneça uma descrição válida");

            RuleFor(attribute => attribute.Description)
                .Length(5, 200).WithMessage("Descrição precisa estar entre 5 e 200 caracteres")
                .NotNull().WithMessage("Descrição não pode ser null")
                .WithMessage("Por favor, forneça uma descrição válida");
        }
    }
}