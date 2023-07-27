using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Applications.Commands.UpdateActor;
using WebApi.DBOperations;

namespace Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommandValidatorTests: IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
      

        public UpdateActorCommandValidatorTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
           
        }

    

        [Theory]
        [InlineData(0,"asd","Asd")]
        [InlineData(0,"as ","ASDF ")]
        [InlineData(1,"asdf"," SD")]
        [InlineData(1,"asd","ASDF")]
        [InlineData(-1,"asdd", " ")]
        [InlineData(1," "," ")]
        [InlineData(1,"","ASD")]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(int actorId, string name, string surname)
        {
            //arrange
            UpdateActorCommand command = new UpdateActorCommand(null);
            command.Model = new UpdateActorModel(){ Name=name, Surname=surname};
            command.ActorId=actorId;
            
            //act
            UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }

        [InlineData(1,"ghchjgjbjugu","ASDF")]
        [Theory]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors(int actorId, string name, string surname)
        {
            UpdateActorCommand command = new UpdateActorCommand(null);
            command.Model = new UpdateActorModel()
            {
                Name = name,
                Surname = surname                
            };
            command.ActorId=actorId;

            UpdateActorCommandValidator validations=new UpdateActorCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().Be(0);
        }


    }
}