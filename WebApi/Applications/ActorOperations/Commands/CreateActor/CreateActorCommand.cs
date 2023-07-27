using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.Commands.CreateActor
{
    public class CreateActorCommand
    {
        public CreateActorModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateActorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
          
           _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var actor = _dbContext.Actors.SingleOrDefault(x => x.Name == Model.Name && x.Surname == Model.Surname);

            if (actor != null)
                throw new InvalidOperationException("Oyuncu zaten mevcut.");

            actor = _mapper.Map<Actor>(Model);

            _dbContext.Actors.Add(actor);
            _dbContext.SaveChanges();
        }
    }

    public class CreateActorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PlayedMovies { get; set; }
    }

        
}