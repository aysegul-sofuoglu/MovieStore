using FluentValidation;

namespace WebApi.Applications.OrderOperations.Commands.UpdateOrder
{
    public class UpdateOrderCommandValdator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValdator()
        {

        }
    }
}