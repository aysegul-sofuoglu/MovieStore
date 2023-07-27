using FluentAssertions;
using TestSetup;
using WebApi.Application.MovieOperations.Commands.DeleteMovie;
using WebApi.DBOperations;
using WebApi.Entities;

namespace Application.MovieOperations.DeleteMovie
{
    public class DeleteMovieCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
     
        

        public DeleteMovieCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAlreadyExistMovieIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange 
            DeleteMovieCommand command = new DeleteMovieCommand(_context);
            

            // act & asset 
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Film Bulunamadı ! ");

        }

        [Fact]
        public void WhenValidInputsAreGiven_Movie_ShouldBeCreated()
        {
            //arrange
           var movie = new Movie() {Title = "WhenValidInputsAreGiven_Movie_ShouldBeCreated", GenreId = 1, Year = "2022", Director = "Aysesofu", Actors = "Ayse", Price = 55 };
           _context.Add(movie);
           _context.SaveChanges();

           DeleteMovieCommand command = new DeleteMovieCommand(_context);
           command.Id = movie.Id;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            movie = _context.Movies.SingleOrDefault(x=> x.Id == movie.Id);
            movie.Should().BeNull();
        }
    
    }

}