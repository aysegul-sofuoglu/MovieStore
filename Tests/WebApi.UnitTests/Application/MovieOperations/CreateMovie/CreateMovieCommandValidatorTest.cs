using FluentAssertions;
using TestSetup;
using WebApi.Application.MovieOperations.Commands.CreateMovie;

namespace Application.MovieOperations.CreateMovie{
    public class CreateMovieCommandValidatorTests : IClassFixture<CommonTestFixture>
    {

            [Theory]
            [InlineData(1,"","2000", "testt", "test", 5)]
            [InlineData(1,"test","2000", "", "test", 5)]
            [InlineData(2,"test","", "testt", "test", 5)]
            [InlineData(2,"test","2000", "", "test", 5)]
            [InlineData(1,"test","2000", "testt", "", 5)]
            [InlineData(2,"test","2000", "testt", "test", 0)]
          
            public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int genreId,string title, string year, string director, string actors, int price )
            {
                //arrange
                CreateMovieCommand command = new CreateMovieCommand(null, null);
                command.Model = new CreateMovieModel()
                {
                    GenreId = genreId ,
                  Title = title,
                  Year = year,
                  Director = director,
                  Actors = actors,
                  Price =price
                   
                };

                //act
                CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
                var result = validator.Validate(command);

                //assert
                result.Errors.Count.Should().BeGreaterThan(0);
            }

           

            [Fact]
            public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
            {
                CreateMovieCommand command = new CreateMovieCommand(null, null);
                command.Model = new CreateMovieModel()
                {
                    GenreId = 1,
                  Title = "Lord Of The Rings",
                  Year = "2022",
                  Director = "aysesofu",
                  Actors = "aysesofu",
                  Price = 66
                   
                };
                CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
                var result = validator.Validate(command);

                result.Errors.Count.Should().Be(0);
            }
    }
}