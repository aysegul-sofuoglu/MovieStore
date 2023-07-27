using FluentAssertions;
using TestSetup;
using WebApi.Applications.Commands.UpdateActor;
using WebApi.DBOperations;

namespace Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        

        public UpdateActorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAlreadyExistActorIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange 
            UpdateActorCommand command = new UpdateActorCommand(_context);
            command.ActorId  = 0;

            // act & asset 
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Actor Does Not Found.");

        }

        [Fact]
        public void WhenGivenActorIdinDB_Actor_ShouldBeUpdate()
        {
            UpdateActorCommand command = new UpdateActorCommand(_context);

            UpdateActorModel model = new UpdateActorModel(){Name="WhenGivenActorIdinDB_Actor_ShouldBeUpdate", Surname="Sofuoğlu"};            
            command.Model = model;
            command.ActorId= 1;

            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var author=_context.Actors.SingleOrDefault(author=>author.Id == command.ActorId);
            author.Should().NotBeNull();
            
        }
    }
}