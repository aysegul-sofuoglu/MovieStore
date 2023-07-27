using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Applications.Commands.CreateActor;
using WebApi.DBOperations;
using WebApi.Entities;

namespace Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateActorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistActorNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange 
            var actor = new Actor() {Name = "Ayşegül", Surname = "Sofuoğlu", PlayedMovies = "Don't Worry Darling", IsAvtive = true};
            _context.Actors.Add(actor);
            _context.SaveChanges();

            CreateActorCommand command = new CreateActorCommand(_context, _mapper);
            command.Model = new CreateActorModel() {Name = actor.Name , Surname = actor.Surname};

            
            // act & asset
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Oyuncu zaten mevcut.");

        }
    }

     


}