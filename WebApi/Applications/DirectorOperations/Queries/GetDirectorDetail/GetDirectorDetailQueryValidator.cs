using FluentValidation;

namespace WebApi.Applications.DirectorOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailQueryValidator : AbstractValidator<GetDirectorDetailQuery>
    {
        public GetDirectorDetailQueryValidator()
	{
		RuleFor(query => query.DirectorId).NotNull().GreaterThan(0);
	}
    }
}