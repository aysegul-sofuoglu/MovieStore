using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.DirectorOperations.Queries.GetDirector
{
    public class GetDirectorQuery
    {
        public GetDirectorModel Model { get; set; }

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDirectorQuery(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _dbContext = movieStoreDbContext;
            _mapper = mapper;
        }

        public List<GetDirectorModel> Handle()
        {
            var directors = _dbContext.Directors.Where(x => x.IsActive == true).ToList<Director>();

            var mapModel = _mapper.Map<List<GetDirectorModel>>(directors);

            return mapModel;

        }


    }

    public class GetDirectorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FilmsDirected { get; set; }

    }
    
}