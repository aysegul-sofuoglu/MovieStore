using FluentValidation;
using WebApi.Applications.DirectorOperations.Commands.CreateDirector;

namespace WebApi.Applications.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
    {
        public UpdateDirectorCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty();
            RuleFor(command => command.Model.Surname).NotEmpty();
            RuleFor(command => command.Model.FilmsDirected).NotEmpty();
        }
    }
}