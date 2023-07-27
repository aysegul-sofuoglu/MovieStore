using FluentValidation;

namespace WebApi.Applications.Commands.CreateActor
{
    public class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>
    {
        public CreateActorCommandValidator()
	{
		RuleFor(command => command.Model.Name).MinimumLength(2).NotEmpty();
		RuleFor(command => command.Model.Surname).MinimumLength(2).NotEmpty();
		RuleFor(command => command.Model.PlayedMovies).NotEmpty();
	}

    }
}