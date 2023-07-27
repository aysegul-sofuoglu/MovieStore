using FluentAssertions;
using TestSetup;
using WebApi.Application.MovieOperations.Commands.DeleteMovie;

namespace Application.MovieOperations.DeleteMovie
{
    public class DeleteMovieCommanValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidMovieIdIsGiven_Validator_ShouldBeReturnErrors(int movieId)
        {
            //arrange
            DeleteMovieCommand command = new DeleteMovieCommand(null!);
            command.Id = movieId;
            
            //act
            DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
    }

        [Theory]
        [InlineData(200)]
        [InlineData(2)]
        public void WhenInvalidBookIdisGiven_Validator_ShouldNotBeReturnError(int movieid)
        {
            DeleteMovieCommand command = new DeleteMovieCommand(null!);
            command.Id = movieid;

            DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
            
        }
}
}