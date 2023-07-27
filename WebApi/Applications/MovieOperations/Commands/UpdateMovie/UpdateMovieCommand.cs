using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommand
    {
        public UpdateMoveiModel Model { get; set; }
        public int MovieId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public UpdateMovieCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle() 
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == MovieId);

            if (movie == null) 
            {
                throw new InvalidOperationException("Film Bulunamadı !");
            }
             

            _mapper.Map<UpdateMoveiModel, Movie>(Model, movie);

            _dbContext.Movies.Update(movie);
            _dbContext.SaveChanges();
        }

    }

    public class UpdateMoveiModel
    {
        public int GenreId { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public int Price { get; set; }
        public bool IsActive { get; set; }

    }
}