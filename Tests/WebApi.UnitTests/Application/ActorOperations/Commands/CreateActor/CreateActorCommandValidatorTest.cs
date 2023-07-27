using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Applications.Commands.CreateActor;
using WebApi.DBOperations;

namespace Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        


        [Theory]
        [InlineData("", "", "")]
        [InlineData("ab", "", "")]
        [InlineData("x", "x", "")]
        [InlineData("xyzt", "x", "")]
        [InlineData("a", "", "as")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name, string surname, string playedMovies  )
        {
        CreateActorCommand command = new CreateActorCommand(null, null );
        command.Model = new CreateActorModel()
        {
            Name = name,
            Surname = surname,
            PlayedMovies = playedMovies  
        };
        
        CreateActorCommandValidator validator = new CreateActorCommandValidator();
        var result = validator.Validate(command);

        result.Errors.Count.Should().BeGreaterThan(0);
        }
    }

  
}