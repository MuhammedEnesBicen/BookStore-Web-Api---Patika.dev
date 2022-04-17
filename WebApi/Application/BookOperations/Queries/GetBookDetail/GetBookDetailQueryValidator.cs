using FluentValidation;

namespace WebApi.Application.BookOperations.GetBookDetail
{
    public class GetBookDetailQueryValidator : AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailQueryValidator()
        {
            RuleFor(query => query.BookId).NotEmpty().GreaterThan(0);

        }
    }
}
