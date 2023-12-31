using FluentValidation;

namespace WebApi.Applications.Commands.DeleteActor
{
    public class DeleteActorCommandValidator : AbstractValidator<DeleteActorCommand>
    {
        public DeleteActorCommandValidator()
        {
            RuleFor(command => command.ActorId).GreaterThan(0);
        }
    }
}