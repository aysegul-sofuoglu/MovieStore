using FluentValidation;

namespace WebApi.Applications.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommandValdator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValdator()
        {
            RuleFor(command => command.Model.MovieId).NotEmpty();
            RuleFor(command => command.Model.CustomerId).NotEmpty();
           
        }
    }
}