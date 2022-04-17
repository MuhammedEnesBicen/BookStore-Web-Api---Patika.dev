using FluentValidation;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetails
{
    public class GetAuthorDetailsQueryValidator : AbstractValidator<GetAuthorDetailsQuery>
    {
        public GetAuthorDetailsQueryValidator()
        {
            RuleFor(query => query.AuthorId).GreaterThan(0);
        }
    }
}
