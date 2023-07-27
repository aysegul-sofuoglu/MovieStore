using FluentValidation;

namespace WebApi.Applications.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty();
            RuleFor(command => command.Model.Surname).NotEmpty();
            RuleFor(command => command.Model.Email).NotEmpty();
            RuleFor(command => command.Model.Password).NotEmpty();
        }
    }
}