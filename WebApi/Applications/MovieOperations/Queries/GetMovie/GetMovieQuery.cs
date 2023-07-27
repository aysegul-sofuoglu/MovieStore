using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.MovieOperations.Queries.GetMovie
{
    public class GetListMovieQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetListMovieQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<MovieViewModel> Handle()
        {
            var movies = _dbContext.Movies.Include(x=> x.Genre)
                .Where(x => x.IsActive == true).OrderBy(x => x.Id).ToList<Movie>();

            List<MovieViewModel> model = _mapper.Map<List<MovieViewModel>>(movies);

            return model;
        }
    }

    public class MovieViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Price { get; set; }

    }
}