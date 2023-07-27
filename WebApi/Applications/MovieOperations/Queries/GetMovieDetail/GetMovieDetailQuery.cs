using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Applications.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQuery
    {
        public int Id { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetMovieDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public MovieDetailModel Handle()
        {
            var movie = _dbContext.Movies.Include(x => x.Genre)
                    .SingleOrDefault(x => x.Id == Id && x.IsActive == true);

            if (movie == null)
                throw new InvalidOperationException("Film Bulunamadı !");

            MovieDetailModel model = _mapper.Map<MovieDetailModel>(movie);

            return model;
        }

    }

    public class MovieDetailModel
    {
        public string Genre { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Director { get; set; }
        public string Players { get; set; }
        public int Price { get; set; }
    }
}