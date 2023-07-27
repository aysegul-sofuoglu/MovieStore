using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Applications.DirectorOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailQuery
    {
        public int DirectorId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDirectorDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {

            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GetDirectorDetailModel Handle()
        {
            var director = _dbContext.Directors.SingleOrDefault(g => g.Id == DirectorId);

            if (director == null)
            {
                throw new InvalidOperationException("Yönetmen  bulunamadı ! ");
            }

            var model = _mapper.Map<GetDirectorDetailModel>(director);

            return model;



        }
    }

    public class GetDirectorDetailModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FilmsDirected { get; set; }

    }
}