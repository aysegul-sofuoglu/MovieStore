using FluentValidation;

namespace WebApi.Applications.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQueryValidator : AbstractValidator<GetMovieDetailQuery>
    {
        public GetMovieDetailQueryValidator()
        {
            RuleFor(query => query.Id).NotNull().GreaterThan(0);
        }
    }
}