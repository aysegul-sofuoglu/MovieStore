using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.MovieOperations.Commands.CreateMovie;
using WebApi.DBOperations;
using WebApi.Entities;

namespace Application.MovieOperations.CreateActor{
    public class CreateMovieCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        

        public CreateMovieCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
            public void WhenAlreadyExistMovieTitleIsGiven_InvalidOperationException_ShouldReturn()
            {
                //arrange
                var movie = new Movie(){Title = "WhenAlreadyExistMovieTitleIsGiven_InvalidOperationException_ShouldReturn", GenreId = 1, Year = "2022", Director = "Aysesofu", Actors = "Ayse", Price = 55 };
                _context.Movies.Add(movie);
                _context.SaveChanges();

                CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
                command.Model = new CreateMovieModel(){Title = movie.Title};


                //act
                FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Film zaten mevcut.");
            }
    }
}