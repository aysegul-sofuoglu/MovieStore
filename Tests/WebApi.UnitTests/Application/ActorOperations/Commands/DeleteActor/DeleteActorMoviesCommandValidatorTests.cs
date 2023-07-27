using FluentAssertions;
using TestSetup;
using WebApi.Applications.Commands.DeleteActor;

namespace Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErorrs(int actorId)
        {
            //arrange
            DeleteActorCommand command = new DeleteActorCommand(null);
            
            command.ActorId = actorId;

            //act
            DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
            var results = validator.Validate(command);

            //assert
            results.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void WhenInvalidActorIdisGiven_Validator_ShouldNotBeReturnError(int actorid)
        {
            DeleteActorCommand command = new DeleteActorCommand(null!);
            command.ActorId = actorid;

            DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
            
        }

    }
}