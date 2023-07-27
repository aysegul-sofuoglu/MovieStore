using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Applications.MovieOperations.Commands.UpdateMovie;
using WebApi.DBOperations;

namespace Application.MovieOperations.UpdateMovie
{
    public class UpdateMovieCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateMovieCommandValidatorTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Theory]
        [InlineData(2,1,"","2020","test","test",65)]
        [InlineData(2,1,"test","","test","test",65)]
        [InlineData(2,1,"test","2020","","test",65)]
        [InlineData(2,1,"","2020","test","",65)]
        [InlineData(2,1,"test","2020","test","test",-5)]

        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(int movieId,int genreId,string title, string year, string director, string actors, int price)
        {
            //arrange
            UpdateMovieCommand command = new UpdateMovieCommand(_context, _mapper);
            command.Model = new UpdateMoveiModel(){ GenreId=genreId,Title=title, Year=year, Director=director, Actors=actors, Price = price};
            command.MovieId=movieId;
            //act
            UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }

        [InlineData(0,2,"test","2000","test","test",55)]
        [Theory]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors(int movieId,int genreId,string title, string year, string director, string actors, int price)
        {
            UpdateMovieCommand command = new UpdateMovieCommand(_context, _mapper);
            command.Model = new UpdateMoveiModel()
            {Title=title, GenreId=genreId, Year=year, Director=director, Actors=actors, Price = price};
            command.MovieId=movieId;

            UpdateMovieCommandValidator validations=new UpdateMovieCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().Be(0);
        }

    }
}