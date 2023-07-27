using FluentValidation;

namespace WebApi.Applications.Commands.UpdateActor
{
    public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
  {
    public UpdateActorCommandValidator()
    {
      RuleFor(command => command.Model.Name).MinimumLength(4);
      RuleFor(command => command.Model.Surname).MinimumLength(4);
    } 
  }
}