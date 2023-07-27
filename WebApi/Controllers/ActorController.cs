using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Applications.ActorOperations.Queries.GetActor;
using WebApi.Applications.ActorOperations.Queries.GetActorDetail;
using WebApi.Applications.Commands.CreateActor;
using WebApi.Applications.Commands.DeleteActor;
using WebApi.Applications.Commands.UpdateActor;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]

    public class ActorController: ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public ActorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetActors()
        {
            GetActorQuery query = new GetActorQuery(_context,_mapper);
            var result = query.Handle();
            return Ok(result);


        }

        [HttpGet("{id}")]
        public IActionResult GetActorDetail(int id)
        {
            GetActorDetailQuery query = new GetActorDetailQuery(_context, _mapper);
            
            query.ActorId = id;

            GetActorDetailQueryValidator validator = new GetActorDetailQueryValidator();
            validator.ValidateAndThrow(query);

            
            
            return Ok(query.Handle());
        }

        [HttpPost]
        public IActionResult AddActor([FromBody] CreateActorModel newActor)
        {
            CreateActorCommand command = new CreateActorCommand(_context, _mapper);
            command.Model = newActor;
            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActor([FromRoute] int id)
        {
            DeleteActorCommand command = new DeleteActorCommand(_context);
            command.ActorId = id;

            command.Handle();

            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult UpdateActor(int id, [FromBody] UpdateActorModel newActor)
        {
            UpdateActorCommand command = new UpdateActorCommand(_context);      
            command.Model = newActor;
            command.ActorId = id;

            UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        
    }

    

}