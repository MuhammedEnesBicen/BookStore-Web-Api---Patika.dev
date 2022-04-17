using FluentValidation;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(command => command.Model.Name).MinimumLength(4).When(x=>x.Model.Name.Trim() != string.Empty);
            // Model.name can be null because of that we bind our rule with a when condition
        }
    }
}
