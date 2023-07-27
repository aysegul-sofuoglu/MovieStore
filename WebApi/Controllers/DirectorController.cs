using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Applications.DirectorOperations.Commands.CreateDirector;
using WebApi.Applications.DirectorOperations.Commands.DeleteDirector;
using WebApi.Applications.DirectorOperations.Commands.UpdateDirector;
using WebApi.Applications.DirectorOperations.Queries.GetDirector;
using WebApi.Applications.DirectorOperations.Queries.GetDirectorDetail;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class DirectorController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public DirectorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDirectors()
        {
            GetDirectorQuery query = new GetDirectorQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public IActionResult GetDirectorDetail(int id)
        {
            GetDirectorDetailModel result;

            GetDirectorDetailQuery query = new GetDirectorDetailQuery(_context, _mapper);
            query.DirectorId = id;

            result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateDirectorModel model)
        {
            CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper);
            command.Model = model;

           
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
            command.DirectorId = id;

            command.Handle();
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateDirectorModel model)
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context, _mapper);

            command.GenreId = id;

            command.Model = model;

            

            command.Handle();
            return Ok();

        }
    }
}