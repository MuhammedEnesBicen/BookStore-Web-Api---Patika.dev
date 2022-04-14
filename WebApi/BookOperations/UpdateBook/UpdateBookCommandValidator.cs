using FluentValidation;
using WebApi.Common;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.BookId).NotEmpty().GreaterThan(0);
            RuleFor(command => command.Model.Title).MinimumLength(2);
            RuleFor(command => command.Model.GenreId).IsInEnum().GreaterThan(0);
            
        }
    }
}
