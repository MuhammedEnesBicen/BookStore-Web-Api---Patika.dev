using FluentValidation;
using System;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            
            RuleFor(command => command.Model.FirstName).MinimumLength(4);
            RuleFor(command => command.Model.LastName).MinimumLength(4);
            RuleFor(command => command.Model.BirthDate).GreaterThan(DateTime.Parse("12/12/0750"));
        }
    }
}
