using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Applications.MovieOperations.Commands.UpdateMovie;
using WebApi.DBOperations;

namespace Application.MovieOperations.UpdateMovie
{
    public class UpdateMovieCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateMovieCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAlreadyExistMovieIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange 
            UpdateMovieCommand command = new UpdateMovieCommand(_context, _mapper);
            command.MovieId = 0;

            // act & asset 
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Film Bulunamadı !");

        }

   
    }
}