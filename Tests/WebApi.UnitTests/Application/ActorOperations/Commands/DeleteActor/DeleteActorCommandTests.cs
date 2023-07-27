using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Applications.Commands.DeleteActor;
using WebApi.DBOperations;

namespace Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommandTests : IClassFixture<CommonTestFixture>
    {
       private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public DeleteActorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenNotExistActorIsGiven_InvalidOperationException_ShouldBeReturnErrors()
        {
            // Given
            DeleteActorCommand command = new DeleteActorCommand(_context);
            command.ActorId = 0;
        
            // When // Then
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Oyuncu Bulunamadı ! ");                    
        }
    }
}