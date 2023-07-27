using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Applications.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailQuery
    {
        public int ActorId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetActorDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public ActorDetailModel Handle()
        {
            var actor = _dbContext.Actors.SingleOrDefault(x => x.Id == ActorId);
            if(actor is null)
                throw new InvalidOperationException("Actor not found.");

            ActorDetailModel model = _mapper.Map<ActorDetailModel>(actor);
            return model;
        }
    }

    public class ActorDetailModel
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string  PlayedMovies { get; set; }
	}
}