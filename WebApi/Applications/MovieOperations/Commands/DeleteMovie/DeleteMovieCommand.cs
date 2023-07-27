using WebApi.DBOperations;

namespace WebApi.Application.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommand
    {
        public int Id { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public DeleteMovieCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle() 
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == Id);

            if (movie == null)
                throw new InvalidOperationException("Film Bulunamadı ! ");

            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();



        }
    }
}