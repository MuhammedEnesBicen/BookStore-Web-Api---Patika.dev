using FluentValidation;
using System;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(command => command.AuthorId).GreaterThan(0);
            RuleFor(command => command.Model.FirstName).MinimumLength(4);
            RuleFor(command => command.Model.LastName).MinimumLength(4);
            RuleFor(command => command.Model.BirthDate).GreaterThan(DateTime.Parse("12/12/0750"));


        }
    }
}
