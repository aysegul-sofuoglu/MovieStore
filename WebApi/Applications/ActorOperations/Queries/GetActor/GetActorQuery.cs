using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.ActorOperations.Queries.GetActor
{
    public class GetActorQuery
    {
        public GetActorModel Model { get; set; }

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetActorQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<GetActorModel> Handle()
        {
            var actors = _dbContext.Actors.Where(x => x.IsAvtive == true).ToList<Actor>();

            var mapModel = _mapper.Map<List<GetActorModel>>(actors);

            return mapModel;

        }


    }

    public class GetActorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PlayedMovies { get; set; }

    }
    
}